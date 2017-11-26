﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.TestEntities
{
    [TestClass]
    public class TestScalarTypes
    {
        [TestMethod]
        public void TestBoolean()
        {
            //And, Or, Equal, Different
            TestAuxiliary.HandleOperations<bool>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.And(),
                    new CorePackage.Execution.Operators.Or(),
                    new CorePackage.Execution.Operators.Equal(CorePackage.Entity.Type.Scalar.Boolean, CorePackage.Entity.Type.Scalar.Boolean),
                    new CorePackage.Execution.Operators.Different(CorePackage.Entity.Type.Scalar.Boolean, CorePackage.Entity.Type.Scalar.Boolean)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", true);
                        i.SetInputValue("RightOperand", true);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", true);
                        i.SetInputValue("RightOperand", false);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", false);
                        i.SetInputValue("RightOperand", true);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", false);
                        i.SetInputValue("RightOperand", false);
                        return true;
                    }
                },
                new List<List<bool>>
                {
                    new List<bool>
                    {
                        true,
                        true,
                        true,
                        false
                    },
                    new List<bool>
                    {
                        false,
                        true,
                        false,
                        true
                    },
                    new List<bool>
                    {
                        false,
                        true,
                        false,
                        true
                    },
                    new List<bool>
                    {
                        false,
                        false,
                        true,
                        false
                    }
                });

            //Not
            TestAuxiliary.HandleOperations<bool>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Not(CorePackage.Entity.Type.Scalar.Boolean)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("Operand", true);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("Operand", false);
                        return true;
                    }
                },
                new List<List<bool>>
                {
                    new List<bool>
                    {
                        false
                    },
                    new List<bool>
                    {
                        true
                    }
                });
        }

        [TestMethod]
        public void TestInteger()
        {
            CorePackage.Entity.DataType integer = CorePackage.Entity.Type.Scalar.Integer;

            //Different, Equal, Greater, GreaterEqual, Less, LessEqual
            TestAuxiliary.HandleOperations<bool>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Different(integer, integer),
                    new CorePackage.Execution.Operators.Equal(integer, integer),
                    new CorePackage.Execution.Operators.Greater(integer, integer),
                    new CorePackage.Execution.Operators.GreaterEqual(integer, integer),
                    new CorePackage.Execution.Operators.Less(integer, integer),
                    new CorePackage.Execution.Operators.LessEqual(integer, integer)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    //greater
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 42);
                        i.SetInputValue("RightOperand", -42);
                        return true;
                    },
                    //equal
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 42);
                        i.SetInputValue("RightOperand", 42);
                        return true;
                    },
                    //less
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", -42);
                        i.SetInputValue("RightOperand", 42);
                        return true;
                    }
                },
                new List<List<bool>>
                {
                    new List<bool>
                    {
                        true,
                        false,
                        true,
                        true,
                        false,
                        false
                    },
                    new List<bool>
                    {
                        false,
                        true,
                        false,
                        true,
                        false,
                        true
                    },
                    new List<bool>
                    {
                        true,
                        false,
                        false,
                        false,
                        true,
                        true
                    }
                }
            );

            //Add, BinaryAnd, BinaryOr, Divide, LeftShift, Modulo, Multiplicate, RightShift, Substract, Xor
            TestAuxiliary.HandleOperations<int>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Add(integer, integer, integer),
                    new CorePackage.Execution.Operators.BinaryAnd(integer, integer, integer),
                    new CorePackage.Execution.Operators.BinaryOr(integer, integer, integer),
                    new CorePackage.Execution.Operators.Divide(integer, integer, integer),
                    new CorePackage.Execution.Operators.LeftShift(integer, integer, integer),
                    new CorePackage.Execution.Operators.Modulo(integer, integer, integer),
                    new CorePackage.Execution.Operators.Multiplicate(integer, integer, integer),
                    new CorePackage.Execution.Operators.RightShift(integer, integer, integer),
                    new CorePackage.Execution.Operators.Substract(integer, integer, integer),
                    new CorePackage.Execution.Operators.Xor(integer, integer, integer)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 42);
                        i.SetInputValue("RightOperand", -42);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 0);
                        i.SetInputValue("RightOperand", 42);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 42);
                        i.SetInputValue("RightOperand", 42);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", -42);
                        i.SetInputValue("RightOperand", -42);
                        return true;
                    }
                },
                new List<List<int>>
                {
                    new List<int>
                    {
                        0,
                        2,
                        -2,
                        -1,
                        176160768,
                        0,
                        -1764,
                        0,
                        84,
                        -4
                    },
                    new List<int>
                    {
                        42,
                        0,
                        42,
                        0,
                        0,
                        0,
                        0,
                        0,
                        -42,
                        42
                    },
                    new List<int>
                    {
                        84,
                        42,
                        42,
                        1,
                        43008,
                        0,
                        1764,
                        0,
                        0,
                        0
                    },
                    new List<int>
                    {
                        -84,
                        -42,
                        -42,
                        1,
                        -176160768,
                        0,
                        1764,
                        -1,
                        0,
                        0
                    }
                }
            );

            //BinaryNot, Decrement, Increment, Inverse
            TestAuxiliary.HandleOperations<int>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.BinaryNot(integer, integer),
                    new CorePackage.Execution.Operators.Decrement(integer, integer),
                    new CorePackage.Execution.Operators.Increment(integer, integer),
                    new CorePackage.Execution.Operators.Inverse(integer, integer)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("Operand", 42);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("Operand", -42);
                        return true;
                    }
                },
                new List<List<int>>
                {
                    new List<int>
                    {
                        -43,
                        41,
                        43,
                        -42
                    },
                    new List<int>
                    {
                        41,
                        -43,
                        -41,
                        42
                    }
                });
        }

        [TestMethod]
        public void TestFloating()
        {
            CorePackage.Entity.DataType floating = CorePackage.Entity.Type.Scalar.Floating;

            //Different, Equal, Greater, GreaterEqual, Less, LessEqual
            TestAuxiliary.HandleOperations<bool>(
                new List<CorePackage.Execution.Operator>
            {
                new CorePackage.Execution.Operators.Different(floating, floating),
                new CorePackage.Execution.Operators.Equal(floating, floating),
                new CorePackage.Execution.Operators.Greater(floating, floating),
                new CorePackage.Execution.Operators.GreaterEqual(floating, floating),
                new CorePackage.Execution.Operators.Less(floating, floating),
                new CorePackage.Execution.Operators.LessEqual(floating, floating)
            },
                new List<Func<CorePackage.Execution.Instruction, bool>>
            {
                (CorePackage.Execution.Instruction i) =>
                {
                    i.SetInputValue("LeftOperand", 3.14);
                    i.SetInputValue("RightOperand", 4.2);
                    return true;
                },
                (CorePackage.Execution.Instruction i) =>
                {
                    i.SetInputValue("LeftOperand", 4.2);
                    i.SetInputValue("RightOperand", 4.2);
                    return true;
                },
                (CorePackage.Execution.Instruction i) =>
                {
                    i.SetInputValue("LeftOperand", 4.2);
                    i.SetInputValue("RightOperand", 3.14);
                    return true;
                }
            },
                new List<List<bool>>
            {
                new List<bool>
                {
                    true,
                    false,
                    false,
                    false,
                    true,
                    true
                },
                new List<bool>
                {
                    false,
                    true,
                    false,
                    true,
                    false,
                    true
                },
                new List<bool>
                {
                    true,
                    false,
                    true,
                    true,
                    false,
                    false
                }
            });

            //Add, Divide, Multiplicate, Substract, Modulo
            TestAuxiliary.HandleOperations<double>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Add(floating, floating, floating),
                    new CorePackage.Execution.Operators.Divide(floating, floating, floating),
                    new CorePackage.Execution.Operators.Multiplicate(floating, floating, floating),
                    new CorePackage.Execution.Operators.Substract(floating, floating, floating),
                    new CorePackage.Execution.Operators.Modulo(floating, floating, floating)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 3.14);
                        i.SetInputValue("RightOperand", 4.2);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 0.0);
                        i.SetInputValue("RightOperand", 4.2);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 3.14);
                        i.SetInputValue("RightOperand", -4.2);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", -3.14);
                        i.SetInputValue("RightOperand", -4.2);
                        return true;
                    }
                },
                new List<List<double>>
                {
                    new List<double>
                    {
                        3.14 + 4.2,
                        3.14 / 4.2,
                        3.14 * 4.2,
                        3.14 - 4.2,
                        3.14 % 4.2
                    },
                    new List<double>
                    {
                        0 + 4.2,
                        0 / 4.2,
                        0 * 4.2,
                        0 - 4.2,
                        0 % 4.2
                    },
                    new List<double>
                    {
                        3.14 + -4.2,
                        3.14 / -4.2,
                        3.14 * -4.2,
                        3.14 - -4.2,
                        3.14 % -4.2
                    },
                    new List<double>
                    {
                        -3.14 + -4.2,
                        -3.14 / -4.2,
                        -3.14 * -4.2,
                        -3.14 - -4.2,
                        -3.14 % -4.2
                    }
                });

            //Decrement, Increment, Inverse
            TestAuxiliary.HandleOperations<double>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Decrement(floating, floating),
                    new CorePackage.Execution.Operators.Increment(floating, floating),
                    new CorePackage.Execution.Operators.Inverse(floating, floating)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("Operand", 4.2);
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("Operand", -4.2);
                        return true;
                    }
                },
                new List<List<double>>
                {
                    new List<double>
                    {
                        3.2,
                        5.2,
                        -4.2
                    },
                    new List<double>
                    {
                        -5.2,
                        -3.2,
                        4.2
                    }
                });
        }

        [TestMethod]
        public void TestCharacter()
        {
            CorePackage.Entity.DataType character = CorePackage.Entity.Type.Scalar.Character;

            //Different, Equal, Greater, GreaterEqual, Less, LessEqual
            TestAuxiliary.HandleOperations<bool>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Different(character, character),
                    new CorePackage.Execution.Operators.Equal(character, character),
                    new CorePackage.Execution.Operators.Greater(character, character),
                    new CorePackage.Execution.Operators.GreaterEqual(character, character),
                    new CorePackage.Execution.Operators.Less(character, character),
                    new CorePackage.Execution.Operators.LessEqual(character, character)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 'A');
                        i.SetInputValue("RightOperand", 'R');
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 'A');
                        i.SetInputValue("RightOperand", 'A');
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", 'R');
                        i.SetInputValue("RightOperand", 'A');
                        return true;
                    }
                },
                new List<List<bool>>
                {
                    new List<bool>
                    {
                        true,
                        false,
                        false,
                        false,
                        true,
                        true
                    },
                    new List<bool>
                    {
                        false,
                        true,
                        false,
                        true,
                        false,
                        true
                    },
                    new List<bool>
                    {
                        true,
                        false,
                        true,
                        true,
                        false,
                        false
                    }
                });
        }

        [TestMethod]
        public void TestString()
        {
            CorePackage.Entity.DataType my_string = CorePackage.Entity.Type.Scalar.String;

            //Different, Equal, Greater, GreaterEqual, Less, LessEqual
            TestAuxiliary.HandleOperations<bool>(
                new List<CorePackage.Execution.Operator>
                {
                    new CorePackage.Execution.Operators.Different(my_string, my_string),
                    new CorePackage.Execution.Operators.Equal(my_string, my_string)
                },
                new List<Func<CorePackage.Execution.Instruction, bool>>
                {
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", "duly");
                        i.SetInputValue("RightOperand", "apero");
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", "duly");
                        i.SetInputValue("RightOperand", "duly");
                        return true;
                    },
                    (CorePackage.Execution.Instruction i) =>
                    {
                        i.SetInputValue("LeftOperand", "apero");
                        i.SetInputValue("RightOperand", "duly");
                        return true;
                    }
                },
                new List<List<bool>>
                {
                    new List<bool>
                    {
                        true,
                        false
                    },
                    new List<bool>
                    {
                        false,
                        true
                    },
                    new List<bool>
                    {
                        true,
                        false
                    }
                });

            //Add
        }
    }
}