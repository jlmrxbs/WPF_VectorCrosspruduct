using System;
using System.Collections.Generic;

namespace MVVM
{
    /// <summary>
    /// Klasse Vectors
    /// </summary>
    /// <remarks>
    /// Klasse hier ausreichend, da kein Objekt auf ein anderes referenziert.
    ///  - Klasse:  Speichern des Werts im Heap, Referenz im Stack
    ///  - Struct:  Speichern Wert und Ref im Stack
    ///  
    /// Beispiel mit class, wo aber struct notwendig wäre:
    /// public static Vectors Crossproduct(Vectors a, Vectors b){
    ///     a.X = 57;  
    ///     Vectors NeuerVektor = a; //beide Objekte a und NeuerVektor referenzieren auf gleiche Adresse im Heap
    ///     NeuerVektor.X = 25; //a.X nimmt Wert 25 an
    ///     return NeuerVektor;
    /// }
    /// </remarks>
    public class Vectors
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }      

        #region Konstruktor
        /// <summary>
        /// Konstruktor 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vectors(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Invertierung/Negation eines Vektors
        /// </summary>
        /// <returns>vector [] double</returns>
        public static Vectors Invert(Vectors a)
        {
            return new Vectors(-a.X, -a.Y, -a.Z);
        }

        /// <summary>
        /// Addition zweier Vektoren
        /// </summary>
        /// <returns>Summe aus Vektor 1 und Vektor 2</returns>
        public static Vectors operator +(Vectors a, Vectors b)
        {
            return new Vectors(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Subtraktion zweier Vektoren
        /// </summary>
        /// <returns>Differenz aus Vektor 1 und Vektor2</returns>
        public static Vectors operator -(Vectors a, Vectors b)
        {
            return new Vectors(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Multiplikation eines Vektors mit einem Faktor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="w"></param>
        /// <returns>Vektor mit Faktor multipliziert</returns>
        public static Vectors operator *(Vectors a, double w)
        {
            return new Vectors(a.X * w, a.Y * w, a.Z * w);
        }

        /// <summary>
        /// Divison eines Vektors mit einem Faktor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="w"></param>
        /// <returns>Vektor durch Faktor dividiert</returns>
        public static Vectors operator /(Vectors a, double w)
        {
            if (w == 0)
            {
                w = 1;
            }

            return new Vectors(a.X / w, a.Y / w, a.Z / w);
        }

        /// <summary>
        /// Skalarprodukt zweier Vektoren (inneres Produkt)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Skalarprodukt</returns>
        public static double Skalar(Vectors a, Vectors b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        /// <summary>
        /// Kreuzprodukt zweier Vektoren (Vektorprodukt)
        /// </summary>
        /// <param name="a">vector a</param>
        /// <param name="b">vector b</param>
        /// <returns>Vektor Kreuzprodukt</returns>
        public static Vectors CrossProduct(Vectors a, Vectors b)
        {
            return new Vectors(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        //Option 2 für Kreuzprodukt:

            //public static Vectors CrossProduct(Vectors a, Vectors b)
            //{
            //    Vectors result;
            //    CrossProduct(a, b, out result);
            //    return result;
            //}
            //internal static void CrossProduct(Vectors a,Vectors b, out Vectors result)
            //{
            //    result = new Vectors();
            //    result.X = a.Y * b.Z - a.Z * b.Y;
            //    result.Y = a.Z * b.X - a.X * b.Z;
            //    result.Z = a.X * b.Y - a.Y * b.X;
            //}

        /// <summary>
        /// Länge eines Vektors
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Länge ines Vektors als Double</returns>
        public static double Laenge(Vectors a)
        {
            return Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
        }

        /// <summary>
        /// Winkel zwischen zwei Vektoren
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Winkel zwischen zwei Vektoren in rad</returns>
        public static double Winkel(Vectors a, Vectors b)
        {
            return Math.Acos(Vectors.Skalar(a, b) / (Vectors.Laenge(a) * Vectors.Laenge(b)));
        }

        #endregion
    }

    public class ObjectComparer : IEqualityComparer<Vectors>
    {
        /// <summary>
        /// Vergleich zweier Vektoren
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Gleich/Ungleich als Boolean</returns>
        public bool Equals(Vectors a, Vectors b)
        {
            if(a==null && b == null) { return false; }
            else if(a==null || b==null) { return false; }
            else if (object.ReferenceEquals(a, b)) { return true; } 

            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        /// <summary>
        /// Erzeugen Hashcode eines Vektors
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Vectors obj)
        {
            return $"{obj.X}{obj.Y}{obj.Y}".GetHashCode();
        }
    }
}
