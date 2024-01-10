using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPSamples.LSP
{
  // Ortak özellikler, farklı ürün aile gruplarında interface ile aktarılır. (Ucak,Helikopter,Kus) 
  //  Bird Can Fly ?  Evet
  // Plane Can Fly ? Evet
  // Plane is Bird ! Hayır (Farklı ürün aile grupları)


  // Aynı ürün aile gruplarında ortak özellikler, kalıtım ile aktarılır (Kus,Köpek,Kedi => Hayvan)
  // Cat is Animal => yes

  public abstract class TwoDimensionGeometricShape
  {
    public abstract double GetArea();
    public abstract double GetPerimeter();
  }

  // Abstract class ile Normal Class kalıtım arasındaki fark ?
  public abstract class TwoDimensionGeometricShapeWithHeightAndWidth: TwoDimensionGeometricShape // 2DGeometricShape
  {
    public double Height { get; set; }
    public double Width { get; set; }

    //public abstract double GetArea(); // Alan hesabı oludğunu biliyoruz fakat nasıl hesaplanacağını suan bilmiyoruz.

    //public abstract double GetPerimeter();
    

  }

  public class Rectangle : TwoDimensionGeometricShapeWithHeightAndWidth
  {
    public override double GetArea()
    {
      return Height * Width;
    }

    public override double GetPerimeter()
    {
      throw new NotImplementedException();
    }
  }


  // 1. Yöntem Kalıtım zincirini bozup, square kendine özgü yazmak
  /*
  public class BadSquare: TwoDimensionGeometricShape
  {
    public double Corner { get; set; }
    public double GetArea()
    {
      //if(Width == Height)
      //{
      //  return 4 * Width;
      //}
      //else
      //{
      //  throw new Exception("Kare olamaz");
      //}

      return 4 * Corner;
    }

    public double GetPerimeter()
    {
      throw new NotImplementedException();
    }
  }
  */

  public class BestSquare : TwoDimensionGeometricShape
  {
    public double Corner { get; set; }
    public override double GetArea()
    {
      return 4 * Corner;
    }

    public override double GetPerimeter()
    {
      throw new NotImplementedException();
    }
  }
}
