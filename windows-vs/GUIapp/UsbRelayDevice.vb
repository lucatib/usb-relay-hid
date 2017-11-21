Imports System.Runtime.InteropServices

Public NotInheritable Class UsbRelayDevice
        Private Sub New()
        End Sub
        ''' <summary>
        ''' Init the USB Relay Libary
        ''' </summary>
        ''' <returns>This function returns 0 on success and -1 on error.</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_init")>
        Public Shared Function Init() As Integer
        End Function

        ''' <summary>
        ''' Finalize the USB Relay Libary.
        ''' This function frees all of the static data associated with
        ''' USB Relay Libary. It should be called at the end of execution to avoid
        ''' memory leaks.
        ''' </summary>
        ''' <returns>This function returns 0 on success and -1 on error.</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_exit")>
        Public Shared Function [Exit]() As Integer
        End Function

        ''' <summary>
        ''' Enumerate the USB Relay Devices.
        ''' </summary>
        ''' <returns></returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_enumerate")>
        Public Shared Function Enumerate() As UsbRelayDeviceInfo
        End Function

        ''' <summary>
        ''' Free an enumeration Linked List
        ''' </summary>
        ''' <param name="deviceInfo"></param>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_free_enumerate")>
        Public Shared Sub FreeEnumerate(deviceInfo As UsbRelayDeviceInfo)
        End Sub

        ''' <summary>
        ''' Open device that serial number is serialNumber
        ''' </summary>
        ''' <param name="serialNumber"></param>
        ''' <param name="stringLength"></param>
        ''' <returns>This funcation returns a valid handle to the device on success or NULL on failure.</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open_with_serial_number", CharSet:=CharSet.Ansi)>
        Public Shared Function OpenWithSerialNumber(<MarshalAs(UnmanagedType.LPStr)> serialNumber As String, stringLength As Integer) As Integer
        End Function

        ''' <summary>
        ''' Open a usb relay device
        ''' </summary>
        ''' <param name="deviceInfo"></param>
        ''' <returns>This funcation returns a valid handle to the device on success or NULL on failure.</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open")>
        Public Shared Function Open(deviceInfo As UsbRelayDeviceInfo) As Integer
        End Function

        ''' <summary>
        ''' Close a usb relay device
        ''' </summary>
        ''' <param name="hHandle"></param>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_close")>
        Public Shared Sub Close(hHandle As Integer)
        End Sub

        ''' <summary>
        ''' open a relay channel on the USB-Relay-Device
        ''' </summary>
        ''' <param name="hHandle">Which usb relay device your want to operate</param>
        ''' <param name="index">Which channel your want to open</param>
        ''' <returns>0 -- success; 1 -- error; 2 -- index is outnumber the number of the usb relay device</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open_one_relay_channel")>
        Public Shared Function OpenOneRelayChannel(hHandle As Integer, index As Integer) As Integer
        End Function

        ''' <summary>
        ''' open all relay channel on the USB-Relay-Device
        ''' </summary>
        ''' <param name="hHandle">which usb relay device your want to operate</param>
        ''' <returns>0 -- success; 1 -- error</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open_all_relay_channel")>
        Public Shared Function OpenAllRelayChannels(hHandle As Integer) As Integer
        End Function

        ''' <summary>
        ''' close a relay channel on the USB-Relay-Device
        ''' </summary>
        ''' <param name="hHandle">which usb relay device your want to operate</param>
        ''' <param name="index">which channel your want to close</param>
        ''' <returns>0 -- success; 1 -- error; 2 -- index is outnumber the number of the usb relay device</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_close_one_relay_channel")>
        Public Shared Function CloseOneRelayChannel(hHandle As Integer, index As Integer) As Integer
        End Function

        ''' <summary>
        ''' close all relay channel on the USB-Relay-Device
        ''' </summary>
        ''' <param name="hHandle">which usb relay device your want to operate</param>
        ''' <returns>0 -- success; 1 -- error</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_close_all_relay_channel")>
        Public Shared Function CloseAllRelayChannels(hHandle As Integer) As Integer
        End Function

        ''' <summary>
        ''' status bit: High --> Low 0000 0000 0000 0000 0000 0000 0000 0000, one bit indicate a relay status.
        ''' the lowest bit 0 indicate relay one status, 1 -- means open status, 0 -- means closed status.
        ''' bit 0/1/2/3/4/5/6/7/8 indicate relay 1/2/3/4/5/6/7/8 status
        ''' </summary>
        ''' <param name="hHandle"></param>
        ''' <param name="status"></param>
        ''' <returns>0 -- success; 1 -- error</returns>
        <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_get_status")>
        Public Shared Function GetStatus(hHandle As Integer, ByRef status As Integer) As Integer
        End Function
    End Class

''' <summary>
''' USB relay board info structure
''' </summary>
<StructLayout(LayoutKind.Sequential, Pack:=8)>
Public Class UsbRelayDeviceInfo
    '<MarshalAs(UnmanagedType.LPStr)>
    Public Property SerialNumber() As String
        Get
            Return m_SerialNumber
        End Get
        Set
            m_SerialNumber = Value
        End Set
    End Property
    Private m_SerialNumber As String

    '<MarshalAs(UnmanagedType.LPStr)>
    Public Property DevicePath() As String
        Get
            Return m_DevicePath
        End Get
        Set
            m_DevicePath = Value
        End Set
    End Property
    Private m_DevicePath As String

    Public Property Type() As UsbRelayDeviceType
        Get
            Return m_Type
        End Get
        Set
            m_Type = Value
        End Set
    End Property
    Private m_Type As UsbRelayDeviceType

    Public Property [Next]() As IntPtr 'UsbRelayDeviceInfo
        Get
            Return m_Next
        End Get
        Set
            m_Next = Value
        End Set
    End Property
    Private m_Next As IntPtr 'UsbRelayDeviceInfo

End Class

Public Enum UsbRelayDeviceType
    OneChannel = 1
    TwoChannel = 2
    FourChannel = 4
    EightChannel = 8
End Enum
