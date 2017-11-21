﻿using System;
using System.Runtime.InteropServices;

namespace UsbRelay
{
    public enum usb_relay_device_type
    {
        USB_RELAY_DEVICE_ONE_CHANNEL = 1,
        USB_RELAY_DEVICE_TWO_CHANNEL = 2,
        USB_RELAY_DEVICE_FOUR_CHANNEL = 4,
        USB_RELAY_DEVICE_EIGHT_CHANNEL = 8
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct usb_relay_device_info
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string serial_number;
        [MarshalAs(UnmanagedType.LPStr)]
        public string device_path;
        public usb_relay_device_type type { get; set; }
        public IntPtr next { get; set; }
    }

    public class RelayDeviceWrapper
    {
        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_enumerate",
        CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.LPStruct)]
        private static extern IntPtr Pusb_relay_device_enumerate();

        public static usb_relay_device_info usb_relay_device_enumerate()
        {
            IntPtr x = RelayDeviceWrapper.Pusb_relay_device_enumerate();
            usb_relay_device_info a = (usb_relay_device_info)Marshal.PtrToStructure(x, typeof(usb_relay_device_info));
            return a;
        }

        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_init", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_init();


        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_open_with_serial_number", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_open_with_serial_number([MarshalAs(UnmanagedType.LPStr)] string serial_number, int len);


        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_close", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern void usb_relay_device_close(int hHandle);

        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_open_all_relay_channel", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_open_all_relay_channel(int hHandle);


        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_close_all_relay_channel", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_close_all_relay_channel(int hHandle);


        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_close_one_relay_channel", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_close_one_relay_channel(int hHandle, int index);


        [DllImport("usb_relay_device.dll", EntryPoint = "usb_relay_device_open_one_relay_channel", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.Cdecl)]
        public static extern int usb_relay_device_open_one_relay_channel(int hHandle, int index);

    }
}
