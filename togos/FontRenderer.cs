using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using IL2CPU.API.Attribs;

namespace togos
{
    class FontRenderer
    {
        Image imagerender;

        public static void FontRender(string sentence, int x, int y, Canvas canvas)
        {
            char[] sentenceSpread = sentence.ToCharArray();
            for(int i = 0; i < sentenceSpread.Length; i++)
            {
                int imaginaryX = i;
                if(imaginaryX == 0)
                {
                    imaginaryX = 1;
                }
                Bitmap map = CreateFont(sentenceSpread[i]);
                canvas.DrawImage(map, (imaginaryX * i) * (int)map.Width, y);
            }
        }

        [ManifestResourceStream(ResourceName = "togos.Resources.0.bmp")]
        public static byte[] zero;

        [ManifestResourceStream(ResourceName = "togos.Resources.1.bmp")]
        public static byte[] one;

        [ManifestResourceStream(ResourceName = "togos.Resources.2.bmp")]
        public static byte[] two;

        [ManifestResourceStream(ResourceName = "togos.Resources.3.bmp")]
        public static byte[] three;

        [ManifestResourceStream(ResourceName = "togos.Resources.4.bmp")]
        public static byte[] four;

        [ManifestResourceStream(ResourceName = "togos.Resources.5.bmp")]
        public static byte[] five;

        [ManifestResourceStream(ResourceName = "togos.Resources.6.bmp")]
        public static byte[] six;

        [ManifestResourceStream(ResourceName = "togos.Resources.7.bmp")]
        public static byte[] seven;

        [ManifestResourceStream(ResourceName = "togos.Resources.8.bmp")]
        public static byte[] eight;

        [ManifestResourceStream(ResourceName = "togos.Resources.9.bmp")]
        public static byte[] nine;

        [ManifestResourceStream(ResourceName = "togos.Resources.fullStop.bmp")]
        public static byte[] fullstop;

        [ManifestResourceStream(ResourceName = "togos.Resources.A.bmp")]
        public static byte[] A;

        [ManifestResourceStream(ResourceName = "togos.Resources.B.bmp")]
        public static byte[] B;

        [ManifestResourceStream(ResourceName = "togos.Resources.C.bmp")]
        public static byte[] C;

        [ManifestResourceStream(ResourceName = "togos.Resources.D.bmp")]
        public static byte[] D;

        [ManifestResourceStream(ResourceName = "togos.Resources.E.bmp")]
        public static byte[] E;

        [ManifestResourceStream(ResourceName = "togos.Resources.F.bmp")]
        public static byte[] F;

        [ManifestResourceStream(ResourceName = "togos.Resources.G.bmp")]
        public static byte[] G;

        [ManifestResourceStream(ResourceName = "togos.Resources.H.bmp")]
        public static byte[] H;

        [ManifestResourceStream(ResourceName = "togos.Resources.I.bmp")]
        public static byte[] I;

        [ManifestResourceStream(ResourceName = "togos.Resources.J.bmp")]
        public static byte[] J;

        [ManifestResourceStream(ResourceName = "togos.Resources.K.bmp")]
        public static byte[] K;

        [ManifestResourceStream(ResourceName = "togos.Resources.L.bmp")]
        public static byte[] L;

        [ManifestResourceStream(ResourceName = "togos.Resources.M.bmp")]
        public static byte[] M;

        [ManifestResourceStream(ResourceName = "togos.Resources.N.bmp")]
        public static byte[] N;

        [ManifestResourceStream(ResourceName = "togos.Resources.O.bmp")]
        public static byte[] O;

        [ManifestResourceStream(ResourceName = "togos.Resources.P.bmp")]
        public static byte[] P;

        [ManifestResourceStream(ResourceName = "togos.Resources.Q.bmp")]
        public static byte[] Q;

        [ManifestResourceStream(ResourceName = "togos.Resources.R.bmp")]
        public static byte[] R;

        [ManifestResourceStream(ResourceName = "togos.Resources.S.bmp")]
        public static byte[] S;

        [ManifestResourceStream(ResourceName = "togos.Resources.T.bmp")]
        public static byte[] T;

        [ManifestResourceStream(ResourceName = "togos.Resources.U.bmp")]
        public static byte[] U;

        [ManifestResourceStream(ResourceName = "togos.Resources.V.bmp")]
        public static byte[] V;

        [ManifestResourceStream(ResourceName = "togos.Resources.W.bmp")]
        public static byte[] W;

        [ManifestResourceStream(ResourceName = "togos.Resources.X.bmp")]
        public static byte[] X;

        [ManifestResourceStream(ResourceName = "togos.Resources.Y.bmp")]
        public static byte[] Y;

        [ManifestResourceStream(ResourceName = "togos.Resources.Z.bmp")]
        public static byte[] Z;

        public static Bitmap CreateFont(char character)
        {
            switch (character)
            {
                case '.':
                    Bitmap fullstopM = new Bitmap(fullstop);
                    return fullstopM;
                    break;
                case '0':
                    Bitmap zeroM = new Bitmap(zero);
                    return zeroM;
                    break;
                case '1':
                    Bitmap oneM = new Bitmap(one);
                    return oneM;
                    break;
                case '2':
                    Bitmap twoM = new Bitmap(two);
                    return twoM;
                    break;
                case '3':
                    Bitmap threeM = new Bitmap(three);
                    return threeM;
                    break;
                case '4':
                    Bitmap fourM = new Bitmap(four);
                    return fourM;
                    break;
                case '5':
                    Bitmap fiveM = new Bitmap(five);
                    return fiveM;
                    break;
                case '6':
                    Bitmap sixM = new Bitmap(six);
                    return sixM;
                    break;
                case '7':
                    Bitmap sevenM = new Bitmap(seven);
                    return sevenM;
                    break;
                case '8':
                    Bitmap eightM = new Bitmap(eight);
                    return eightM;
                    break;
                case '9':
                    Bitmap nineM = new Bitmap(nine);
                    return nineM;
                    break;
                case 'A':
                    Bitmap AM = new Bitmap(A);
                    return AM;
                    break;
                case 'B':
                    Bitmap BM = new Bitmap(B);
                    return BM;
                    break;
                case 'C':
                    Bitmap CM = new Bitmap(C);
                    return CM;
                    break;
                case 'D':
                    Bitmap DM = new Bitmap(D);
                    return DM;
                    break;
                case 'E':
                    Bitmap EM = new Bitmap(E);
                    return EM;
                    break;
                case 'F':
                    Bitmap FM = new Bitmap(F);
                    return FM;
                    break;
                case 'G':
                    Bitmap GM = new Bitmap(G);
                    return GM;
                    break;
                case 'H':
                    Bitmap HM = new Bitmap(H);
                    return HM;
                    break;
                case 'I':
                    Bitmap IM = new Bitmap(I);
                    return IM;
                    break;
                case 'J':
                    Bitmap JM = new Bitmap(J);
                    return JM;
                    break;
                case 'K':
                    Bitmap KM = new Bitmap(K);
                    return KM;
                    break;
                case 'L':
                    Bitmap LM = new Bitmap(L);
                    return LM;
                    break;
                case 'M':
                    Bitmap MM = new Bitmap(M);
                    return MM;
                    break;
                case 'N':
                    Bitmap NM = new Bitmap(N);
                    return NM;
                    break;
                case 'O':
                    Bitmap OM = new Bitmap(O);
                    return OM;
                    break;
                case 'P':
                    Bitmap PM = new Bitmap(P);
                    return PM;
                    break;
                case 'R':
                    Bitmap RM = new Bitmap(R);
                    return RM;
                    break;
                case 'S':
                    Bitmap SM = new Bitmap(S);
                    return SM;
                    break;
                case 'T':
                    Bitmap TM = new Bitmap(T);
                    return TM;
                    break;
                case 'U':
                    Bitmap UM = new Bitmap(U);
                    return UM;
                    break;
                case 'V':
                    Bitmap VM = new Bitmap(V);
                    return VM;
                    break;
                case 'W':
                    Bitmap WM = new Bitmap(W);
                    return WM;
                    break;
                case 'X':
                    Bitmap XM = new Bitmap(X);
                    return XM;
                    break;
                case 'Y':
                    Bitmap YM = new Bitmap(Y);
                    return YM;
                    break;
                case 'Z':
                    Bitmap ZM = new Bitmap(Z);
                    return ZM;
                    break;
                default:
                    Bitmap ZE = new Bitmap(Z);
                    return ZE;
                    break;
                    
            }
        }
    }
}
