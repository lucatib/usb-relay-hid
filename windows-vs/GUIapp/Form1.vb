Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mdevlist As IntPtr = usb_relay_device_enumerate()
        Dim mdev As usb_relay_device_info = CType(Marshal.PtrToStructure(mdevlist, GetType(usb_relay_device_info)), usb_relay_device_info)
        Dim mresult As Integer = usb_relay_device_open(mdev)

    End Sub
End Class
