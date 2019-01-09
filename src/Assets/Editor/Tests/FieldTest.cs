using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class FieldTest {

    [Test]
    public void ElementCompare() {
        Assert.AreEqual(new Element(1), new Element(1));
        Assert.AreNotEqual(new Element(1), new Element(2));
    }

    [Test]
    public void Field3HorisontalLine() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(2), new Element(3), new Element(0) },
            { new Element(1), new Element(3), new Element(3), new Element(2) },
            { new Element(0), new Element(0), new Element(1), new Element(0) },
            { new Element(2), new Element(2), new Element(2), new Element(3) }
        };

        field.CheckCoincedence();

        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                   { new Element(2), new Element(2), new Element(3), new Element(0) },
            { new Element(1), new Element(3), new Element(3), new Element(2) },
            { new Element(0), new Element(0), new Element(1), new Element(0) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(3) }
                }
            )
        );
    }

    [Test]
    public void Field3VerticalLine() {
        Field field = new Field(3, 6);
        field.grid = new Element[,] {
            { new Element(1), new Element(3), new Element(1) },
            { new Element(1), new Element(2), new Element(2) },
            { new Element(1), new Element(4), new Element(5) }
        };

        field.CheckCoincedence();

        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                    { new Element(-1), new Element(3), new Element(1) },
                    { new Element(-1), new Element(2), new Element(2) },
                    { new Element(-1), new Element(4), new Element(5) }
                }
            )
        );
    }

     [Test]
    public void Field4VerticalLine() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4) },
            { new Element(0), new Element(2), new Element(2), new Element(1) },
            { new Element(1), new Element(1), new Element(2), new Element(3) },
            { new Element(0), new Element(2), new Element(2), new Element(1) }
        };

        field.CheckCoincedence();

       // Assert.AreEqual(field.fieldSize, 4);
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                    { new Element(0), new Element(3), new Element(-1), new Element(4) },
                    { new Element(0), new Element(2), new Element(-1), new Element(1) },
                    { new Element(1), new Element(1), new Element(-1), new Element(3) },
                    { new Element(0), new Element(2), new Element(-1), new Element(1) }
                }
            )
        );
    }

    [Test]
    public void Field4HorizontalLine() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4) },
            { new Element(0), new Element(2), new Element(2), new Element(1) },
            { new Element(1), new Element(1), new Element(3), new Element(3) },
            { new Element(0), new Element(0), new Element(0), new Element(0) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                    { new Element(0), new Element(3), new Element(2), new Element(4) },
                    { new Element(0), new Element(2), new Element(2), new Element(1) },
                    { new Element(1), new Element(1), new Element(3), new Element(3) },
                    { new Element(-1), new Element(-1), new Element(-1), new Element(-1) }
                }
            )
        );
    }

    [Test]
    public void Field5Type1() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(1), new Element(1), new Element(3), new Element(3), new Element(3) },
            { new Element(0), new Element(0), new Element(3), new Element(2), new Element(4) },
            { new Element(0), new Element(0), new Element(3), new Element(0), new Element(2) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                    { new Element(0), new Element(-1), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(1), new Element(1), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(0), new Element(0), new Element(-1), new Element(2), new Element(4) },
            { new Element(0), new Element(0), new Element(-1), new Element(0), new Element(2) }
                }
            )
        );
    }
    [Test]
    public void Field5Type2() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(3), new Element(3), new Element(3), new Element(0), new Element(3) },
            { new Element(0), new Element(3), new Element(4), new Element(2), new Element(4) },
            { new Element(0), new Element(3), new Element(3), new Element(0), new Element(2) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                   { new Element(0), new Element(-1), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(0), new Element(-1) },
            { new Element(0), new Element(-1), new Element(4), new Element(2), new Element(4) },
            { new Element(0), new Element(-1), new Element(-1), new Element(0), new Element(2) }
                }
            )
        );
    }

     [Test]
    public void Field5Type3() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(4), new Element(4), new Element(4), new Element(0), new Element(3) },
            { new Element(2), new Element(0), new Element(4), new Element(2), new Element(4) },
            { new Element(0), new Element(3), new Element(4), new Element(0), new Element(2) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                   { new Element(0), new Element(3), new Element(2), new Element(-1), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(0), new Element(3) },
            { new Element(2), new Element(0), new Element(-1), new Element(2), new Element(-1) },
            { new Element(0), new Element(3), new Element(-1), new Element(0), new Element(2) }
                 }
            )
        );
    }

    [Test]
    public void Field5Type4() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(1), new Element(1) },
            { new Element(4), new Element(3), new Element(1), new Element(0), new Element(3) },
            { new Element(2), new Element(0), new Element(1), new Element(1), new Element(1) },
            { new Element(0), new Element(3), new Element(1), new Element(0), new Element(2) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                    { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(-1), new Element(-1) },
            { new Element(4), new Element(3), new Element(-1), new Element(0), new Element(3) },
            { new Element(2), new Element(0), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(0), new Element(3), new Element(-1), new Element(0), new Element(2) }
                 }
            )
        );
    }

    [Test]
    public void Field5Type5() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(4), new Element(2), new Element(1), new Element(1) },
            { new Element(4), new Element(4), new Element(4), new Element(0), new Element(3) },
            { new Element(2), new Element(4), new Element(3), new Element(4), new Element(1) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(2) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                   { new Element(0), new Element(3), new Element(2), new Element(-1), new Element(0) },
            { new Element(0), new Element(-1), new Element(2), new Element(1), new Element(1) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(0), new Element(3) },
            { new Element(2), new Element(-1), new Element(3), new Element(-1), new Element(1) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(2) }
                 }
            )
        );
    }

    [Test]
    public void Field5Type6() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(4), new Element(2), new Element(1), new Element(1) },
            { new Element(3), new Element(1), new Element(0), new Element(0), new Element(3) },
            { new Element(2), new Element(4), new Element(3), new Element(3), new Element(3) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(3) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                  { new Element(0), new Element(-1), new Element(2), new Element(4), new Element(0) },
            { new Element(0), new Element(4), new Element(2), new Element(1), new Element(1) },
            { new Element(-1), new Element(1), new Element(0), new Element(0), new Element(-1) },
            { new Element(2), new Element(4), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(0), new Element(-1), new Element(1), new Element(-1), new Element(-1) }
                 }
            )
        );
    }

    [Test]
    public void Field5Type7() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(2), new Element(4), new Element(5) },
            { new Element(0), new Element(4), new Element(2), new Element(1), new Element(5) },
            { new Element(3), new Element(1), new Element(5), new Element(5), new Element(5) },
            { new Element(2), new Element(4), new Element(2), new Element(1), new Element(4) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(5) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                  { new Element(0), new Element(3), new Element(2), new Element(4), new Element(-1) },
            { new Element(0), new Element(4), new Element(2), new Element(1), new Element(-1) },
            { new Element(3), new Element(1), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(2), new Element(4), new Element(2), new Element(1), new Element(4) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(-1) }
                 }
            )
        );
    }

    [Test]
    public void Field5Type8() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(0), new Element(4), new Element(0) },
            { new Element(0), new Element(4), new Element(2), new Element(1), new Element(5) },
            { new Element(3), new Element(1), new Element(2), new Element(0), new Element(0) },
            { new Element(0), new Element(2), new Element(2), new Element(2), new Element(4) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(5) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                 new Element[,] {
                   { new Element(0), new Element(3), new Element(0), new Element(4), new Element(0) },
            { new Element(0), new Element(4), new Element(-1), new Element(1), new Element(5) },
            { new Element(3), new Element(1), new Element(-1), new Element(0), new Element(0) },
            { new Element(0), new Element(-1), new Element(-1), new Element(-1), new Element(4) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(5) }
                 }
            )
        );
    }
    [Test]
    public void Field5Type9() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(0), new Element(3), new Element(0), new Element(4), new Element(0) },
            { new Element(0), new Element(4), new Element(0), new Element(1), new Element(5) },
            { new Element(3), new Element(1), new Element(0), new Element(0), new Element(0) },
            { new Element(0), new Element(4), new Element(5), new Element(2), new Element(4) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(5) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                    { new Element(-1), new Element(3), new Element(-1), new Element(4), new Element(-1) },
                    { new Element(-1), new Element(4), new Element(-1), new Element(1), new Element(5) },
                    { new Element(3), new Element(1), new Element(-1), new Element(-1), new Element(-1) },
                    { new Element(-1), new Element(4), new Element(5), new Element(2), new Element(4) },
                    { new Element(-1), new Element(3), new Element(1), new Element(3), new Element(5) }
                 }
            )
        );
    }

    [Test]
    public void Field5HorizontalLine() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(3), new Element(1), new Element(4), new Element(0) },
            { new Element(5), new Element(4), new Element(3), new Element(1), new Element(5) },
            { new Element(0), new Element(0), new Element(0), new Element(0), new Element(0) },
            { new Element(3), new Element(4), new Element(5), new Element(2), new Element(4) },
            { new Element(0), new Element(3), new Element(1), new Element(3), new Element(5) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                { new Element(2), new Element(3), new Element(1), new Element(4), new Element(-1) },
            { new Element(5), new Element(4), new Element(3), new Element(1), new Element(5) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(3), new Element(4), new Element(5), new Element(2), new Element(4) },
            { new Element(-1), new Element(3), new Element(1), new Element(3), new Element(5) }
                 }
            )
        );
    }

    [Test]
    public void Field5VercticalLine() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(4), new Element(1), new Element(4), new Element(0) },
            { new Element(5), new Element(4), new Element(3), new Element(1), new Element(5) },
            { new Element(5), new Element(4), new Element(0), new Element(5), new Element(0) },
            { new Element(3), new Element(4), new Element(5), new Element(2), new Element(4) },
            { new Element(0), new Element(4), new Element(1), new Element(3), new Element(5) }
        };

        field.CheckCoincedence();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                { new Element(2), new Element(-1), new Element(1), new Element(-1), new Element(0) },
            { new Element(5), new Element(-1), new Element(3), new Element(1), new Element(5) },
            { new Element(5), new Element(-1), new Element(0), new Element(5), new Element(0) },
            { new Element(3), new Element(-1), new Element(5), new Element(2), new Element(-1) },
            { new Element(0), new Element(-1), new Element(1), new Element(3), new Element(5) }
                }
            )
        );
    }

       [Test]
    public void FallTest() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(5), new Element(1), new Element(-1), new Element(0) },
            { new Element(0), new Element(1), new Element(3), new Element(1), new Element(-1) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(5), new Element(3) },
            { new Element(-1), new Element(1), new Element(-1), new Element(1), new Element(-1) },
            { new Element(5), new Element(1), new Element(-1), new Element(-1), new Element(-1) }
        };

        field.FallElements();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                { new Element(-1), new Element(-1), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(-1), new Element(5), new Element(-1), new Element(-1), new Element(-1) },
            { new Element(2), new Element(1), new Element(-1), new Element(1), new Element(-1) },
            { new Element(0), new Element(1), new Element(1), new Element(5), new Element(0) },
            { new Element(5), new Element(1), new Element(3), new Element(1), new Element(3) }
                }
            )
        );
    }

    [Test]
    public void SwapTest() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(2), new Element(3), new Element(0) },
            { new Element(1), new Element(3), new Element(3), new Element(2) },
            { new Element(0), new Element(2), new Element(1), new Element(0) },
            { new Element(2), new Element(0), new Element(2), new Element(3)}
        };

        int score = field.Swap(2,1,3,1);
       
        Assert.AreEqual(true, field.AreCellsNearby(2,1,3,1));
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                    { new Element(-1), new Element(-1), new Element(-1), new Element(0) },
                    { new Element(2), new Element(2), new Element(3), new Element(2) },
                    { new Element(1), new Element(3), new Element(3), new Element(0) },
                    { new Element(0), new Element(0), new Element(1), new Element(3) } 
                }
            )
        );
    }

    public void FillUpByBallsTest() {
        Field field = new Field(5, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(5), new Element(1), new Element(1), new Element(0) },
            { new Element(0), new Element(1), new Element(3), new Element(1), new Element(5) },
            { new Element(1), new Element(5), new Element(1), new Element(5), new Element(3) },
            { new Element(3), new Element(1), new Element(5), new Element(1), new Element(1) },
            { new Element(5), new Element(1), new Element(3), new Element(3), new Element(5) }
        };

        field.Swap(1,1,2,1);
        field.FillUpByBalls();

       
        Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                    { new Element(100), new Element(100), new Element(100), new Element(100), new Element(100) },
                    { new Element(2), new Element(100), new Element(100), new Element(100), new Element(0) },
                    { new Element(0), new Element(100), new Element(3), new Element(100), new Element(5) },
                    { new Element(3), new Element(5), new Element(5), new Element(5), new Element(3) },
                    { new Element(5), new Element(5), new Element(3), new Element(3), new Element(5) }
                }
            )
        );
    }

    [Test]
    public void MainCheck() {
        Field field = FieldGenerator.InitialFieldGeneration(15, 6);

        int a = 0;

        for(int i = 0; i < 15; i++)
            for(int j = 0; j < 15; j++)
                if(field.grid[i,j].type == -1)
                    a += 1;
        
        Assert.AreEqual(0, a);
    }

     [Test]
    public void IsTurnPossbleTest() {
        Field field = new Field(7, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(0), new Element(1), new Element(5), new Element(3), new Element(2), new Element(0)},
            { new Element(3), new Element(5), new Element(0), new Element(4), new Element(1), new Element(4), new Element(1)},
            { new Element(0), new Element(1), new Element(3), new Element(5), new Element(2), new Element(5), new Element(0)},
            { new Element(1), new Element(0), new Element(2), new Element(0), new Element(1), new Element(3), new Element(2)},
            { new Element(3), new Element(1), new Element(4), new Element(3), new Element(2), new Element(0), new Element(4)},
            { new Element(1), new Element(4), new Element(3), new Element(5), new Element(0), new Element(1), new Element(5)},
            { new Element(5), new Element(0), new Element(2), new Element(1), new Element(2), new Element(3), new Element(0)}
        };

        bool possible = field.IsTurnPossible();
        Assert.AreEqual(true, possible);
    }

       [Test]
    public void AreCellsNearbyTest() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(2), new Element(3), new Element(0) },
            { new Element(1), new Element(3), new Element(3), new Element(2) },
            { new Element(0), new Element(2), new Element(1), new Element(0) },
            { new Element(2), new Element(0), new Element(2), new Element(3)}
        };
        
        bool a = field.AreCellsNearby(2,1,3,1);
        Assert.AreEqual(true, a);
    }

    


    [Test]
    public void IsAnyLineTest() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(2), new Element(3), new Element(0) },
            { new Element(1), new Element(3), new Element(3), new Element(2) },
            { new Element(0), new Element(0), new Element(1), new Element(0) },
            { new Element(-1), new Element(-1), new Element(-1), new Element(3)}
        };
        
        bool a = field.IsAnyLineExist();
        Assert.AreEqual(true, a);
    }

    [Test]
    public void TestManyLines() {
        Field field = new Field(4, 6);
        field.grid = new Element[,] {
            { new Element(2), new Element(5), new Element(3), new Element(0) },
            { new Element(1), new Element(2), new Element(3), new Element(2) },
            { new Element(2), new Element(1), new Element(1), new Element(0) },
            { new Element(1), new Element(2), new Element(2), new Element(3)}
        };
        
        int points = field.Swap(2,0,2,1);
        Assert.AreEqual(10, points);

         Assert.That(
            field.grid,
            Is.EquivalentTo(
                new Element[,] {
                { new Element(-1), new Element(-1), new Element(3), new Element(0) },
                { new Element(-1), new Element(-1), new Element(3), new Element(2) },
                { new Element(-1), new Element(-1), new Element(1), new Element(0) },
                { new Element(  2), new Element(5), new Element(2), new Element(3)}
            }
            )
        );
    }
}