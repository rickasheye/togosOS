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
        //A Font renderer that isnt working!!!
        Image imagerender;

        public static void FontRender(string sentence, int x, int y, Canvas canvas)
        {
        }

        [ManifestResourceStream(ResourceName = "togos.Resources.0.bmp")]
        public static byte[] zero;

        [ManifestResourceStream(ResourceName = "togos.Resources.1.bmp")]
        public static byte[] one;

        [ManifestResourceStream(ResourceName = "togos.Resources.2.bmp")]
        public static byte[] two ;

        [ManifestResourceStream(ResourceName = "togos.Resources.3.bmp")]
        public static byte[] three ;

        [ManifestResourceStream(ResourceName = "togos.Resources.4.bmp")]
        public static byte[] four ;

        [ManifestResourceStream(ResourceName = "togos.Resources.5.bmp")]
        public static byte[] five ;

        [ManifestResourceStream(ResourceName = "togos.Resources.6.bmp")]
        public static byte[] six ;

        [ManifestResourceStream(ResourceName = "togos.Resources.7.bmp")]
        public static byte[] seven ;

        [ManifestResourceStream(ResourceName = "togos.Resources.8.bmp")]
        public static byte[] eight ;

        [ManifestResourceStream(ResourceName = "togos.Resources.9.bmp")]
        public static byte[] nine ;

        [ManifestResourceStream(ResourceName = "togos.Resources.fullStop.bmp")]
        public static byte[] fullstop ;

        [ManifestResourceStream(ResourceName = "togos.Resources.A.bmp")]
        public static byte[] A ;

        [ManifestResourceStream(ResourceName = "togos.Resources.B.bmp")]
        public static byte[] B ;

        [ManifestResourceStream(ResourceName = "togos.Resources.C.bmp")]
        public static byte[] C ;

        [ManifestResourceStream(ResourceName = "togos.Resources.D.bmp")]
        public static byte[] D ;

        [ManifestResourceStream(ResourceName = "togos.Resources.E.bmp")]
        public static byte[] E ;

        [ManifestResourceStream(ResourceName = "togos.Resources.F.bmp")]
        public static byte[] F ;

        [ManifestResourceStream(ResourceName = "togos.Resources.G.bmp")]
        public static byte[] G ;

        [ManifestResourceStream(ResourceName = "togos.Resources.H.bmp")]
        public static byte[] H ;

        [ManifestResourceStream(ResourceName = "togos.Resources.I.bmp")]
        public static byte[] I ;

        [ManifestResourceStream(ResourceName = "togos.Resources.J.bmp")]
        public static byte[] J ;

        [ManifestResourceStream(ResourceName = "togos.Resources.K.bmp")]
        public static byte[] K ;

        [ManifestResourceStream(ResourceName = "togos.Resources.L.bmp")]
        public static byte[] L ;

        [ManifestResourceStream(ResourceName = "togos.Resources.M.bmp")]
        public static byte[] M ;

        [ManifestResourceStream(ResourceName = "togos.Resources.N.bmp")]
        public static byte[] N ;

        [ManifestResourceStream(ResourceName = "togos.Resources.O.bmp")]
        public static byte[] O ;

        [ManifestResourceStream(ResourceName = "togos.Resources.P.bmp")]
        public static byte[] P ;

        [ManifestResourceStream(ResourceName = "togos.Resources.Q.bmp")]
        public static byte[] Q ;

        [ManifestResourceStream(ResourceName = "togos.Resources.R.bmp")]
        public static byte[] R ;

        [ManifestResourceStream(ResourceName = "togos.Resources.S.bmp")]
        public static byte[] S ;

        [ManifestResourceStream(ResourceName = "togos.Resources.T.bmp")]
        public static byte[] T ;

        [ManifestResourceStream(ResourceName = "togos.Resources.U.bmp")]
        public static byte[] U ;

        [ManifestResourceStream(ResourceName = "togos.Resources.V.bmp")]
        public static byte[] V ;

        [ManifestResourceStream(ResourceName = "togos.Resources.W.bmp")]
        public static byte[] W ;

        [ManifestResourceStream(ResourceName = "togos.Resources.X.bmp")]
        public static byte[] X ;

        [ManifestResourceStream(ResourceName = "togos.Resources.Y.bmp")]
        public static byte[] Y ;

        [ManifestResourceStream(ResourceName = "togos.Resources.Z.bmp")]
        public static byte[] Z ;

        public static Bitmap CreateFont(char character)
        {
            Bitmap finalChosen = null;
            switch (character)
            {
                case '.':
                    Bitmap fullstopM = new Bitmap(fullstop);
                    finalChosen = fullstopM;
                    break;
                case '0':
                    Bitmap zeroM = new Bitmap(zero);
                    finalChosen = zeroM;
                    break;
                case '1':
                    Bitmap oneM = new Bitmap(one);
                    finalChosen = oneM;
                    break;
                case '2':
                    Bitmap twoM = new Bitmap(two);
                    finalChosen = twoM;
                    break;
                case '3':
                    Bitmap threeM = new Bitmap(three);
                    finalChosen = threeM;
                    break;
                case '4':
                    Bitmap fourM = new Bitmap(four);
                    finalChosen = fourM;
                    break;
                case '5':
                    Bitmap fiveM = new Bitmap(five);
                    finalChosen = fiveM;
                    break;
                case '6':
                    Bitmap sixM = new Bitmap(six);
                    finalChosen = sixM;
                    break;
                case '7':
                    Bitmap sevenM = new Bitmap(seven);
                    finalChosen = sevenM;
                    break;
                case '8':
                    Bitmap eightM = new Bitmap(eight);
                    finalChosen = eightM;
                    break;
                case '9':
                    Bitmap nineM = new Bitmap(nine);
                    finalChosen = nineM;
                    break;
                case 'A':
                    Bitmap AM = new Bitmap(A);
                    finalChosen = AM;
                    break;
                case 'B':
                    Bitmap BM = new Bitmap(B);
                    finalChosen = BM;
                    break;
                case 'C':
                    Bitmap CM = new Bitmap(C);
                    finalChosen = CM;
                    break;
                case 'D':
                    Bitmap DM = new Bitmap(D);
                    finalChosen = DM;
                    break;
                case 'E':
                    Bitmap EM = new Bitmap(E);
                    finalChosen = EM;
                    break;
                case 'F':
                    Bitmap FM = new Bitmap(F);
                    finalChosen = FM;
                    break;
                case 'G':
                    Bitmap GM = new Bitmap(G);
                    finalChosen = GM;
                    break;
                case 'H':
                    Bitmap HM = new Bitmap(H);
                    finalChosen = HM;
                    break;
                case 'I':
                    Bitmap IM = new Bitmap(I);
                    finalChosen = IM;
                    break;
                case 'J':
                    Bitmap JM = new Bitmap(J);
                    finalChosen = JM;
                    break;
                case 'K':
                    Bitmap KM = new Bitmap(K);
                    finalChosen = KM;
                    break;
                case 'L':
                    Bitmap LM = new Bitmap(L);
                    finalChosen = LM;
                    break;
                case 'M':
                    Bitmap MM = new Bitmap(M);
                    finalChosen = MM;
                    break;
                case 'N':
                    Bitmap NM = new Bitmap(N);
                    finalChosen = NM;
                    break;
                case 'O':
                    Bitmap OM = new Bitmap(O);
                    finalChosen = OM;
                    break;
                case 'P':
                    Bitmap PM = new Bitmap(P);
                    finalChosen = PM;
                    break;
                case 'R':
                    Bitmap RM = new Bitmap(R);
                    finalChosen = RM;
                    break;
                case 'S':
                    Bitmap SM = new Bitmap(S);
                    finalChosen = SM;
                    break;
                case 'T':
                    Bitmap TM = new Bitmap(T);
                    finalChosen = TM;
                    break;
                case 'U':
                    Bitmap UM = new Bitmap(U);
                    finalChosen = UM;
                    break;
                case 'V':
                    Bitmap VM = new Bitmap(V);
                    finalChosen = VM;
                    break;
                case 'W':
                    Bitmap WM = new Bitmap(W);
                    finalChosen = WM;
                    break;
                case 'X':
                    Bitmap XM = new Bitmap(X);
                    finalChosen = XM;
                    break;
                case 'Y':
                    Bitmap YM = new Bitmap(Y);
                    finalChosen = YM;
                    break;
                case 'Z':
                    Bitmap ZM = new Bitmap(Z);
                    finalChosen = ZM;
                    break; 
            }
            return finalChosen;
        }

        public static void RenderLineFont(char a, Canvas canvas, int offset)
        {
            Pen pen = new Pen(System.Drawing.Color.Black);
            switch (a)
            {
                case 'A':
                    canvas.DrawLine(pen, new Point(1 + offset, 0 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(1 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    break;
                case 'B':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(2 + offset, 0 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(2 + offset, 2 + offset));
                    break;
                case 'C':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(2 + offset, 2 + offset));
                    break;
                case 'D':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(2 + offset, 0 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(2 + offset, 2 + offset));
                    break;
                case 'E':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(2 + offset, 2 + offset));
                    break;
                case 'F':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    break;
                case 'G':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(2 + offset, 1 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(1 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(2 + offset, 2 + offset));
                    break;
                case 'H':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(2 + offset, 0 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    break;
                case 'I':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(2 + offset, 0 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 1 + offset), new Point(2 + offset, 1 + offset));
                    break;
                case 'J':
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(2 + offset, 0 + offset), new Point(2 + offset, 2 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 0 + offset), new Point(2 + offset, 0 + offset));
                    canvas.DrawLine(pen, new Point(0 + offset, 2 + offset), new Point(2 + offset, 2 + offset));
                    break;
                case 'K':
                    break;
                case 'L':
                    break;
                case 'N':
                    break;
                case 'M':
                    break;
                case 'O':
                    break;
                case 'P':
                    break;
                case 'Q':
                    break;
                case 'R':
                    break;
                case 'S':
                    break;
                case 'T':
                    break;
                case 'U':
                    break;
                case 'V':
                    break;
                case 'W':
                    break;
                case 'Y':
                    break;
                case 'X':
                    break;
                case 'Z':
                    break;
            }
        }
    }
}
