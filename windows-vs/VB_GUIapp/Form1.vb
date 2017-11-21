Imports System.Runtime.InteropServices
Imports UsbRelay

Public Class Form1

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RelayDeviceWrapper.usb_relay_init()
        Dim minfo As usb_relay_device_info = RelayDeviceWrapper.usb_relay_device_enumerate()
        Dim mhandle As Integer = RelayDeviceWrapper.usb_relay_device_open_with_serial_number(minfo.serial_number, minfo.serial_number.Length)
        RelayDeviceWrapper.usb_relay_device_open_one_relay_channel(mhandle, 0)
        RelayDeviceWrapper.usb_relay_device_open_one_relay_channel(mhandle, 1)
        RelayDeviceWrapper.usb_relay_device_open_one_relay_channel(mhandle, 2)
    End Sub
End Class
