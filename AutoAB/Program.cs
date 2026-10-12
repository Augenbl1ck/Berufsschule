using System;
namespace Schule
{
    //Definition der Klasse Auto
    class Auto
    {
        int m_Geschwindigkeit;
        int m_höchstGeschwingigkeit;
        public Auto() //Der Default-Konstruktor
        {
            m_Geschwindigkeit = 0;
        }

        public Auto(int höchstGeschwingigkeit) //Der Default-Konstruktor
        {
            m_Geschwindigkeit = 0;
            m_höchstGeschwingigkeit = höchstGeschwingigkeit;
        }
        public void Beschleunige()
        {
            if(!(m_Geschwindigkeit++ > m_höchstGeschwingigkeit))
            {
                m_Geschwindigkeit++;
            }
           
        }

        public void Beschleunige(int wert)
        {
            if(!(m_Geschwindigkeit + wert > m_höchstGeschwingigkeit)){
                m_Geschwindigkeit += wert;
            }
        }

        public void Bremse()
        {
            if(m_Geschwindigkeit < 10 && m_Geschwindigkeit != 0)
            {
                m_Geschwindigkeit = 0;
            }
            else
            {
                m_Geschwindigkeit -= 10;
            }
        }

        public void Fahre()
        {
            Console.WriteLine("Ich fahre mit {0} km/h.", m_Geschwindigkeit);
        }
    }
    class Program
    {
        public static void Main()
        {
            Auto meinAuto;
            meinAuto = new Auto(50);
            meinAuto.Beschleunige(9);
            meinAuto.Fahre();
            meinAuto.Beschleunige(30);
            meinAuto.Fahre();
            meinAuto.Bremse();
            meinAuto.Bremse();
            meinAuto.Bremse();
            meinAuto.Bremse();
            meinAuto.Fahre();
        }
    }
}