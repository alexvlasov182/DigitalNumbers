namespace System;

class DigitalNumbers
{
  static void Main()
  {
    var input = Console.ReadLine();

    // validate input
    var inputValidator = new IntValidator();
    inputValidator.Validate(input);

    var matrixCollection = new MatrixCollection();

    try
    {
      var matricies = input?.Select(c => matrixCollection.GetMatrix(c));
      // print output
      var height = matricies?.First().Length;

      for (int lineNumber = 0; lineNumber < height; ++lineNumber)
      {
        var lines = matricies?.Select(m => m[lineNumber]);
        if (lines != null)
        {
          foreach (var line in lines)
          {
            foreach (string element in line)
            {
              Console.Write(element);
            }
          }
          Console.WriteLine();
        }
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      return;
    }
  }

  public class IntValidator
  {
    public void Validate(string? input)
    {
      var isValid = int.TryParse(input, out var _);
      if (!isValid)
      {
        throw new ArgumentException("Invalid input");
      }
    }
  }

  public class MatrixCollection
  {
    public string[][] GetMatrix(char c)
    {
      return c switch
      {
        '0' => new string[][]
        {
          new [] {" ", "_", " "},
          new [] {"|", " ", "|"},
          new [] {"|", "_", "|"},
        },
        '1' => new string[][]
        {
          new [] {" ", " ", " "},
          new [] {" ", " ", "|"},
          new [] {" ", " ", "|"},
        },
        '2' => new string[][]
       {
          new [] {" ", "_", " "},
          new [] {" ", "_", "|"},
          new [] {"|", "", "_"}},
        '3' => new string[][]
        {
          new [] {" ", "_", " "},
          new [] {" ", "_", "|"},
          new [] {" ", " _", "|"}
        },
        '4' => new string[][]
        {
          new [] {" ", " ", " "},
          new [] {"|", "_", "|"},
          new [] {" ", " ", "|"},
        },
        '5' => new string[][]
        {
          new [] {" ", " ", "_"},
          new [] {" |", "_", " "},
          new [] {" ", " _", "|"}
        },
        '6' => new string[][]
        {
          new [] {" ", " ", " _"},
          new [] {" |", "_", " "},
          new [] {" |", "_", "|"}
        },
        '7' => new string[][]
        {
          new [] {" ", " _", " "},
          new [] {" ", " ", "|"},
          new [] {" ", " ", "|"}
        },
        '8' => new string[][]
        {
          new [] {" ", " _", " "},
          new [] {" |", "_", "|"},
          new [] {" |", "_", "|"}
        },
        '9' => new string[][]
        {
          new [] {" ", " _", " "},
          new [] {" |", "_", "|"},
          new [] {" ", " _", "|"}
        },
        _ => throw new ArgumentOutOfRangeException(nameof(c), c, "no matrix exsists for taht int")
      };
    }
  }
}