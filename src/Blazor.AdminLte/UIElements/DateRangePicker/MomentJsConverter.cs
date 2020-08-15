using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Blazor.AdminLte
{
    public static class MomentJsConverter
    {
        private enum State
        {
            None,
            LowerA,
            CapitalA,
            LowerD1,
            LowerD2,
            LowerD3,
            LowerD4,
            CapitalD1,
            CapitalD2,
            LowerH1,
            LowerH2,
            CapitalH1,
            CapitalH2,
            LowerM1,
            LowerM2,
            CapitalM1,
            CapitalM2,
            CapitalM3,
            CapitalM4,
            LowerS1,
            LowerS2,
            CapitalS1,
            CapitalS2,
            CapitalS3,
            CapitalS4,
            CapitalS5,
            CapitalS6,
            CapitalS7,
            CapitalY1,
            CapitalY2,
            CapitalY3,
            CapitalY4,
            CapitalZ
        }

        private static string InnerGenerateCSharpFormatString(string momentJsFormat)
        {
            StringBuilder resultBuilder = new StringBuilder();
            State resultState = State.None;
            StringBuilder tokenBuffer = new StringBuilder();

            var ChangeState = new Action<State>((State fNewState) =>
            {
                switch (resultState)
                {
                    case State.LowerA:
                    case State.CapitalA:
                        resultBuilder.Append("tt");
                        break;
                    case State.LowerD3:
                        resultBuilder.Append("ddd");
                        break;
                    case State.LowerD4:
                        resultBuilder.Append("dddd");
                        break;
                    case State.CapitalD1:
                        resultBuilder.Append("d");
                        break;
                    case State.CapitalD2:
                        resultBuilder.Append("dd");
                        break;
                    case State.LowerH1:
                        resultBuilder.Append("h");
                        break;
                    case State.LowerH2:
                        resultBuilder.Append("hh");
                        break;
                    case State.CapitalH1:
                        resultBuilder.Append("H");
                        break;
                    case State.CapitalH2:
                        resultBuilder.Append("HH");
                        break;
                    case State.LowerM1:
                        resultBuilder.Append("m");
                        break;
                    case State.LowerM2:
                        resultBuilder.Append("mm");
                        break;
                    case State.CapitalM1:
                        resultBuilder.Append("M");
                        break;
                    case State.CapitalM2:
                        resultBuilder.Append("MM");
                        break;
                    case State.CapitalM3:
                        resultBuilder.Append("MMM");
                        break;
                    case State.CapitalM4:
                        resultBuilder.Append("MMMM");
                        break;
                    case State.LowerS1:
                        resultBuilder.Append("s");
                        break;
                    case State.LowerS2:
                        resultBuilder.Append("ss");
                        break;
                    case State.CapitalS1:
                        resultBuilder.Append("f");
                        break;
                    case State.CapitalS2:
                        resultBuilder.Append("ff");
                        break;
                    case State.CapitalS3:
                        resultBuilder.Append("fff");
                        break;
                    case State.CapitalS4:
                        resultBuilder.Append("ffff");
                        break;
                    case State.CapitalS5:
                        resultBuilder.Append("fffff");
                        break;
                    case State.CapitalS6:
                        resultBuilder.Append("ffffff");
                        break;
                    case State.CapitalS7:
                        resultBuilder.Append("fffffff");
                        break;
                    case State.CapitalY2:
                        resultBuilder.Append("yy");
                        break;
                    case State.CapitalY4:
                        resultBuilder.Append("yyyy");
                        break;
                    case State.CapitalZ:
                        resultBuilder.Append("zzz");
                        break;
                }

                tokenBuffer.Clear();
                resultState = fNewState;
            });

            foreach (var character in momentJsFormat)
            {
                switch (character)
                {
                    case 'a':
                        switch (resultState)
                        {
                            case State.LowerA:
                                break;
                            default:
                                ChangeState(State.LowerA);
                                break;
                        }
                        break;
                    case 'A':
                        switch (resultState)
                        {
                            case State.CapitalA:
                                break;
                            default:
                                ChangeState(State.CapitalA);
                                break;
                        }
                        break;
                    case 'd':
                        switch (resultState)
                        {
                            case State.LowerD1:
                                resultState = State.LowerD2;
                                break;
                            case State.LowerD2:
                                resultState = State.LowerD3;
                                break;
                            case State.LowerD3:
                                resultState = State.LowerD4;
                                break;
                            case State.LowerD4:
                                break;
                            default:
                                ChangeState(State.LowerD1);
                                break;
                        }
                        break;
                    case 'D':
                        switch (resultState)
                        {
                            case State.CapitalD1:
                                resultState = State.CapitalD2;
                                break;
                            case State.CapitalD2:
                                break;
                            default:
                                ChangeState(State.CapitalD1);
                                break;
                        }
                        break;
                    case 'h':
                        switch (resultState)
                        {
                            case State.LowerH1:
                                resultState = State.LowerH2;
                                break;
                            case State.LowerH2:
                                break;
                            default:
                                ChangeState(State.LowerH1);
                                break;
                        }
                        break;
                    case 'H':
                        switch (resultState)
                        {
                            case State.CapitalH1:
                                resultState = State.CapitalH2;
                                break;
                            case State.CapitalH2:
                                break;
                            default:
                                ChangeState(State.CapitalH1);
                                break;
                        }
                        break;
                    case 'm':
                        switch (resultState)
                        {
                            case State.LowerM1:
                                resultState = State.LowerM2;
                                break;
                            case State.LowerM2:
                                break;
                            default:
                                ChangeState(State.LowerM1);
                                break;
                        }
                        break;
                    case 'M':
                        switch (resultState)
                        {
                            case State.CapitalM1:
                                resultState = State.CapitalM2;
                                break;
                            case State.CapitalM2:
                                resultState = State.CapitalM3;
                                break;
                            case State.CapitalM3:
                                resultState = State.CapitalM4;
                                break;
                            case State.CapitalM4:
                                break;
                            default:
                                ChangeState(State.CapitalM1);
                                break;
                        }
                        break;
                    case 's':
                        switch (resultState)
                        {
                            case State.LowerS1:
                                resultState = State.LowerS2;
                                break;
                            case State.LowerS2:
                                break;
                            default:
                                ChangeState(State.LowerS1);
                                break;
                        }
                        break;
                    case 'S':
                        switch (resultState)
                        {
                            case State.CapitalS1:
                                resultState = State.CapitalS2;
                                break;
                            case State.CapitalS2:
                                resultState = State.CapitalS3;
                                break;
                            case State.CapitalS3:
                                resultState = State.CapitalS4;
                                break;
                            case State.CapitalS4:
                                resultState = State.CapitalS5;
                                break;
                            case State.CapitalS5:
                                resultState = State.CapitalS6;
                                break;
                            case State.CapitalS6:
                                resultState = State.CapitalS7;
                                break;
                            case State.CapitalS7:
                                break;
                            default:
                                ChangeState(State.CapitalS1);
                                break;
                        }
                        break;
                    case 'Y':
                        switch (resultState)
                        {
                            case State.CapitalY1:
                                resultState = State.CapitalY2;
                                break;
                            case State.CapitalY2:
                                resultState = State.CapitalY3;
                                break;
                            case State.CapitalY3:
                                resultState = State.CapitalY4;
                                break;
                            case State.CapitalY4:
                                break;
                            default:
                                ChangeState(State.CapitalY1);
                                break;
                        }
                        break;
                    case 'Z':
                        switch (resultState)
                        {
                            case State.CapitalZ:
                                break;
                            default:
                                ChangeState(State.CapitalZ);
                                break;
                        }
                        break;
                    default:
                        ChangeState(State.None);
                        resultBuilder.Append(character);
                        break;
                }
            }

            ChangeState(State.None);
            return resultBuilder.ToString();
        }

        public static string GenerateCSharpFormatString(string momentJsFormat)
        {
            string[] subStrs = Regex.Split(momentJsFormat, @"(\[[^\]]+\])");
            var res = new StringBuilder();
            foreach (var subStr in subStrs)
            {
                if (subStr.Contains("["))
                {
                    res.Append(Regex.Replace(subStr, @"[\[\]]", "'"));
                }
                else
                {
                    res.Append(InnerGenerateCSharpFormatString(subStr));
                }
            }
            return res.ToString();
        }
    }
}
