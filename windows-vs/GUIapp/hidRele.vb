Imports System.Runtime.InteropServices

Module hidRele
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=1)>
    Public Structure usb_relay_device_info
        Public serial_number As String
        Public device_path As String
        Public type As UInt32
        Public [Next] As IntPtr
    End Structure

    <DllImport("USB_RELAY_DEVICE.dll", SetLastError:=True)> Function usb_relay_device_enumerate _
     () As IntPtr
    End Function
    <DllImport("USB_RELAY_DEVICE.dll", SetLastError:=True)> Function usb_relay_device_free_enumerate _
     (ByRef DeviceInterfaceData As usb_relay_device_info) As Boolean
    End Function
    <DllImport("USB_RELAY_DEVICE.dll", SetLastError:=True)> Function usb_relay_device_open _
     (ByRef device_info As usb_relay_device_info) As Integer
    End Function

    Public Enum UsbRelayDeviceType
        OneChannel = 1
        TwoChannel = 2
        FourChannel = 4
        EightChannel = 8
    End Enum
End Module
