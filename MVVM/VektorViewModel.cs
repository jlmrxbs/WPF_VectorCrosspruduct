using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Collections.ObjectModel;

namespace MVVM
{
    public class VektorViewModel : BaseViewModel
    {
        public DelegateCommand ClearCommand { get; set; }
        public DelegateCommand CalculateCommand { get; set; }


        /// <summary>
        /// Ausgewählte Operation: Kreuzprodukt
        /// </summary>
        string operatorToExecute = "cross";
        public double Factor = 5.1;

        /// <summary>
        /// Initialize Commands
        /// </summary>
        public VektorViewModel()
        {
      
            //Clear Fields
            this.ClearCommand = new DelegateCommand(
                (obj)=> X1 != 0 || X2 !=0 || Y1 != 0 || Y2 != 0 || Z1 != 0 || Z2 != 0,
                (obj)=>
                {
                    this.X1 = 0;
                    this.X2 = 0;
                    this.Y1 = 0;
                    this.Y2 = 0;
                    this.Z2 = 0;
                    this.Z1 = 0;
                    this.ResValueX = 0;
                    this.ResValueY = 0;
                    this.ResValueZ = 0;
                }
                );

            //Berechne Kreuzprodukt
            this.CalculateCommand = new DelegateCommand((obj) =>
            {string op = (string)obj;

                if(op == "=")
                {
                    switch (operatorToExecute)
                    {
                        //Beispielhaft andere Operationen aufgeführt
                        case "+":
                            Results = Vector1 + Vector2;
                            break;
                        case "-":
                            Results = Vector2 - Vector1;
                            break;
                        case "*":
                            Results = Vector1 * Factor;
                            break;
                        case "/":
                            Results = Vector1 / Factor;
                            break;
                        case "cross":
                            Results = Vectors.CrossProduct(Vector1, Vector2);
                            break;
                        default:
                            break;
                    }
                    ResValueX = Results.X;
                    ResValueY = Results.Y;
                    ResValueZ = Results.Z;
                }
                
            });

            //Default
            this.X1 = 1.0;
            this.Y1 = 5.0;
            this.Z1 = 7.0;

            this.X2 = -3;
            this.Y2 = -7;
            this.Z2 = 2;
        }


        /// <summary>
        /// Hole Werte für Ergebnisfelder und detektiere Änderungen
        /// </summary>
        double currResValueX;
        public double ResValueX
        {
            get => currResValueX;
            set
            {
                if(currResValueX != value)
                {
                    currResValueX = value;
                    this.ChangeValue();
                }
            }
        }

        double currResValueY;
        public double ResValueY
        {
            get => currResValueY;
            set
            {
                if (currResValueY != value)
                {
                    currResValueY = value;
                    this.ChangeValue();
                }
            }
        }

        double currResValueZ;
        public double ResValueZ
        {
            get => currResValueZ;
            set
            {
                if (currResValueZ != value)
                {
                    currResValueZ = value;
                    this.ChangeValue();
                }
            }
        }

        /// <summary>
        /// Ergebnisvektor Results
        /// Vektor 1: Vector1
        /// Vektor 2: Vector2
        /// </summary>
        public Vectors Results { get; set; }
        public Vectors Vector1
        {
            get { return new Vectors(X1, Y1, Z1); }
        }      
        public Vectors Vector2
        {
            get { return new Vectors(X2, Y2, Z2); }
        }

        /// <summary>
        /// Hole Werte für Vektor 1 und detektiere Änderungen
        /// </summary>
        double valueX1;
        
            public double X1
            {
                get =>  valueX1;
                set
                {
                    if(valueX1 != value)
                    {
                        valueX1 = value;
                        
                        this.ChangeValue();
                        this.ClearCommand.CanCommandExecute();
                }
                }
            }

            double valueY1;
            public double Y1
            {
                get => valueY1;
                set
                {
                    if (valueY1 != value)
                    {
                        valueY1 = value;
                        this.ChangeValue();
                        this.ClearCommand.CanCommandExecute();
                }
                }
            }

            double valueZ1;
            public double Z1
            {
                get => valueZ1;
                set
                {
                    if (valueZ1 != value)
                    {
                        valueZ1 = value;
                        this.ChangeValue();
                        this.ClearCommand.CanCommandExecute();
                }
                }
            }


        /// <summary>
        /// Hole Werte für Vektor 2 und detektiere Änderungen
        /// </summary>
        double valueX2;
            public double X2
            {
                get => valueX2;
                set
                {
                    if (valueX2 != value)
                    {
                        valueX2=value;
                        this.ChangeValue();
                }
                }
            }

            double valueY2;
            public double Y2
            {
                get => valueY2;
                set
                {
                    if (valueY2 != value)
                    {
                        valueY2 = value;
                        this.ChangeValue();
                        this.ClearCommand.CanCommandExecute();
                }
                }
            }

            double valueZ2;
            public double Z2
            {
                get => valueZ2;
                set
                {
                    if (valueZ2 != value)
                    {
                        valueZ2 = value;
                        this.ChangeValue();
                        this.ClearCommand.CanCommandExecute();
                }
                }
            }


    }

}
