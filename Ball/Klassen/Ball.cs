
using System;

namespace Ball
{
	public class Ball
	{
		//Position des Balls
		int _PosX;
		int _PosY;
		//Bewegungsrichtung (1 oder -1)
		int _RichtungX;
		int _RichtungY;
		
		public Ball()
		{
			_PosX = 0;
			_PosY = 0;
			_RichtungX = 1;
			_RichtungY = 1;
		}
		
		public Ball(int posx, int posy, int rx, int ry)
		{
			_PosX = posx;
			_PosY = posy;
			_RichtungX = rx;
			_RichtungY = ry;
		}
		
		public void Zeichne()
		{
			Console.SetCursorPosition(_PosX , _PosY);
			Console.Write("O");
		}
		public void Loesche()
		{
			Console.SetCursorPosition(_PosX , _PosY);
			Console.Write(" ");
		}
		public void Bewege()
		{
			_PosX += _RichtungX;
			_PosY += _RichtungY;

			if (_PosX <= 0 || _PosX >= Console.WindowWidth - 1)
			{
				_RichtungX *= -1;
			}

			if (_PosY <= 0 || _PosY >= Console.WindowHeight - 1)
			{
				_RichtungY *= -1;
			}
		}

	}
}
