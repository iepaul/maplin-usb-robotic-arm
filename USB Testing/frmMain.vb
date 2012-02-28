Imports LibUsbDotNet
Imports LibUsbDotNet.Main
Imports System.Runtime.InteropServices

Public Class frmMain

    Private RobotArm As UsbDevice

    ' State properties
    ' Ints set to -1 for reverse direction and 1 for forward direction of motor, 0 to stop
    Public GripperState As Integer
    Public WristState As Integer
    Public ElbowState As Integer
    Public ShoulderState As Integer
    Public BaseState As Integer
    Public LightState As Boolean

    ' Concatenates property values into three-byte control packet
    Private Function BuildControlPacket() As Byte()
        Dim val1 As Byte = 0
        Dim val2 As Byte = 0
        Dim val3 As Byte = 0

        If GripperState = -1 Then val1 += 1
        If GripperState = 1 Then val1 += 2

        If WristState = -1 Then val1 += 4
        If WristState = 1 Then val1 += 8
        If ElbowState = -1 Then val1 += 10
        If ElbowState = 1 Then val1 += 20
        If ShoulderState = -1 Then val1 += 40
        If ShoulderState = 1 Then val1 += 80

        If BaseState = -1 Then val2 += 1
        If BaseState = 1 Then val2 += 2

        If LightState Then val3 = 1

        Return New Byte() {val1, val2, val3}


    End Function

    ' Connect to the arm
    Public Function ConnectArm() As Boolean
        ' Vendor ID/Product ID here
        Dim USBFinder As New UsbDeviceFinder(&H1267, &H0)

        ' Try to open the device
        RobotArm = UsbDevice.OpenUsbDevice(USBFinder)

        ' Did we connect OK?
        If (RobotArm Is Nothing) Then Return False

        ' If this is a "whole" usb device (libusb-win32, linux libusb)
        ' it will have an IUsbDevice interface. If not (WinUSB) the 
        ' variable will be null indicating this is an interface of a 
        ' device.
        Dim wholeUsbDevice As IUsbDevice = TryCast(RobotArm, IUsbDevice)
        If Not ReferenceEquals(wholeUsbDevice, Nothing) Then
            ' This is a "whole" USB device. Before it can be used, 
            ' the desired configuration and interface must be selected.

            ' Select config #1
            wholeUsbDevice.SetConfiguration(1)

            ' Claim interface #0.
            wholeUsbDevice.ClaimInterface(0)
        End If

        ' Connected and have interface to the arm
        Return True

    End Function

    ' Call this function to send a control packet to the arm
    Public Sub UpdateArm()
        Dim usbPacket As UsbSetupPacket
        Dim data As Byte() = BuildControlPacket()
        data = BuildControlPacket()

        Dim transferred As Integer

        Dim ptr As IntPtr = Marshal.AllocHGlobal(3) ' alloc 3 bytes
        Marshal.Copy(data, 0, ptr, 3) ' copy control packet

        usbPacket = New UsbSetupPacket(Convert.ToByte(UsbRequestType.TypeVendor), 6, &H100, 0, 0)
        RobotArm.ControlTransfer(usbPacket, ptr, data.Length, transferred)
    End Sub

    ' Cleanup method - call this when you've finished 
    Public Sub CleanupArm()
        If Not (RobotArm Is Nothing) Then
            If RobotArm.IsOpen Then
                Dim wholeUsbDevice = TryCast(RobotArm, IUsbDevice)
                If Not ReferenceEquals(wholeUsbDevice, Nothing) Then
                    ' This is a "whole" USB device. Before it can be used, 
                    ' the desired configuration and interface must be selected.

                    ' Select config #1
                    wholeUsbDevice.ReleaseInterface(0)
                End If

                RobotArm.Close()
                UsbDevice.Exit()

            End If
        End If
    End Sub

    Private Sub btnLightOn_Click(sender As System.Object, e As System.EventArgs) Handles btnLightOn.Click
        If ConnectArm() Then
            LightState = True
            UpdateArm()
        Else
            MsgBox("No arm connected!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub btnLightOff_Click(sender As System.Object, e As System.EventArgs) Handles btnLightOff.Click
        If ConnectArm() Then
            LightState = False
            UpdateArm()
        Else
            MsgBox("No arm connected!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub btnLeft_Click(sender As System.Object, e As System.EventArgs) Handles btnLeft.Click
        If ConnectArm() Then
            BaseState = -1
            UpdateArm()
            System.Threading.Thread.Sleep(50)
            BaseState = 0
            UpdateArm()
        Else
            MsgBox("No arm connected!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnRight_Click(sender As System.Object, e As System.EventArgs) Handles btnRight.Click
        If ConnectArm() Then
            BaseState = 1
            UpdateArm()
            System.Threading.Thread.Sleep(50)
            BaseState = 0
            UpdateArm()
        Else
            MsgBox("No arm connected!", MsgBoxStyle.Critical)
        End If
    End Sub

End Class