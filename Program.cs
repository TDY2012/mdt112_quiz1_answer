using System;
using System.Collections.Generic;

class Helper
{
    public static int GCD( int a, int b )
    {
        while( a!=0 && b!=0 )
        {
            if (a > b)
                a -= (a / b)*b;
            else
                b -= (b / a)*a;
        }
        return a == 0 ? b : a;
    }

    public static int GCD( List<int> n )
    {
        int result = n[0];
        for (int i = 1; i < n.Count; i++)
            result = GCD(result, n[i]);
        return result;
    }

    public static int LCM(int a, int b)
    {
        return a*b/GCD(a,b);
    }

    public static int LCM(List<int> n)
    {
        int result = n[0];
        for (int i = 1; i < n.Count; i++)
            result = LCM(result, n[i]);
        return result;
    }

    public static List<int> QuickSort(List<int> n)
    {
        if (n.Count <= 1)
            return n;
        List<int> less = new List<int>();
        List<int> more = new List<int>();
        for(int i=1; i<n.Count; i++)
        {
            if (n[i] < n[0])
                less.Add(n[i]);
            else
                more.Add(n[i]);
        }
        less = QuickSort(less);
        more = QuickSort(more);
        less.Add(n[0]);
        less.AddRange(more);
        return less;
    }

    public static int GetNextAbacusState(int currentState, int toggleIndex)
    {
        if(toggleIndex == 4)
        {
            return currentState >= 5 ? currentState - 5 : currentState + 5;
        }
        else
        {
            toggleIndex = 3 - toggleIndex;
            return (currentState % 5) <= toggleIndex ? (currentState / 5) * 5 + toggleIndex + 1 : (currentState / 5) * 5 + toggleIndex;
        }
    }

    public static float[] GetIntercept(float width, float height, float[] p, float[] u)
    {
        float testX = u[0] >= 0 ? width : 0;
        float testY = u[1] >= 0 ? height : 0;

        float interceptX = ((u[0] / u[1]) * (testY - p[1])) + p[0];
        float interceptY = ((u[1] / u[0]) * (testX - p[0])) + p[1];

        float[] intercept = new float[2];
        if (interceptX < 0 || interceptX > width)
        {
            intercept[0] = testX;
            intercept[1] = interceptY;
        }
        else
        {
            intercept[0] = interceptX;
            intercept[1] = testY;
        }
        return intercept;
    }

    public static List<string> GetSideNameList(float width, float height, float[] pointOnSide)
    {
        List<string> sideNameList = new List<string>();
        if (pointOnSide[0] == 0)
            sideNameList.Add("Left");
        if (pointOnSide[0] == width)
            sideNameList.Add("Right");
        if (pointOnSide[1] == 0)
            sideNameList.Add("Bottom");
        if (pointOnSide[1] == height)
            sideNameList.Add("Top");
        return sideNameList;
    }

    public static float[] GetReflectedVector(string sideName, float[] u)
    {
        float[] v = {u[0],u[1]};
        if (sideName == "Left" || sideName == "Right")
            v[0] = -v[0];
        else
            v[1] = -v[1];
        return v;
    }
}

class Vector2
{
    public int X, Y;
    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector2 operator +(Vector2 u)
    {
        return u;
    }

    public static Vector2 operator -(Vector2 u)
    {
        return new Vector2(-u.X, -u.Y);
    }

    public static Vector2 operator +(Vector2 u, Vector2 v)
    {
        return new Vector2(u.X+v.X, u.Y+v.Y);
    }

    public static Vector2 operator -(Vector2 u, Vector2 v)
    {
        return u + (-v);
    }

    public static int Cross( Vector2 u, Vector2 v)
    {
        return (u.X * v.Y) - (u.Y * v.X);
    }
}

namespace quiz1_answer
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizNo1();
            //QuizNo2();
            //QuizNo3()
            //QuizNo4();
            //QuizNo5();
            //QuizNo6();
        }
        
        /// <summary>
        /// Greatest Common Divisor
        /// </summary>
        static void QuizNo1()
        {
            List<int> n = new List<int>();
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if(input <= 0)
                    break;
                n.Add(input);
            }
            Console.WriteLine(Helper.GCD(n));
            Console.Read();
        }

        /// <summary>
        /// Least Common Multiplier
        /// </summary>
        static void QuizNo2()
        {
            List<int> n = new List<int>();
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input <= 0)
                    break;
                n.Add(input);
            }
            Console.WriteLine(Helper.LCM(n));
            Console.Read();
        }

        /// <summary>
        /// Quick Sort
        /// </summary>
        static void QuizNo3()
        {
            List<int> n = new List<int>();
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input <= 0)
                    break;
                n.Add(input);
            }
            foreach(int x in Helper.QuickSort(n))
            {
                Console.WriteLine(x);
            }
            Console.Read();
        }

        /// <summary>
        /// Abacus
        /// </summary>
        static void QuizNo4()
        {
            int abacusState = int.Parse(Console.ReadLine());

            List<int> toggleIndexList = new List<int>();
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input < 0 || input > 4)
                    break;
                toggleIndexList.Add(input);
            }
            foreach (int x in toggleIndexList)
            {
                abacusState = Helper.GetNextAbacusState(abacusState, x);
            }
            Console.WriteLine(abacusState);
            Console.Read();
        }

        /// <summary>
        /// Concave Polygon and Convex Polygon
        /// </summary>
        static void QuizNo5()
        {
            int numSide = int.Parse(Console.ReadLine());

            List<Vector2> vertices = new List<Vector2>();
            for(int i = 0; i < numSide; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                vertices.Add(new Vector2(x, y));
            }

            List<Vector2> edges = new List<Vector2>();
            for(int i = 0; i < numSide; i++)
            {
                edges.Add(vertices[(i + 1) % numSide] - vertices[i]);
            }

            bool isConcave = false;
            for (int i = 0; i < numSide; i++)
            {
                if(Vector2.Cross( edges[(i + 1) % numSide], edges[i] ) > 0)
                {
                    isConcave = true;
                    break;
                }
            }

            if (isConcave)
                Console.WriteLine("Concave");
            else
                Console.WriteLine("Convex");
            Console.Read();
        }

        /// <summary>
        /// DVD Player
        /// </summary>
        static void QuizNo6()
        {
            float width = float.Parse(Console.ReadLine());
            float height = float.Parse(Console.ReadLine());
            float uX = float.Parse(Console.ReadLine());
            float uY = float.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            float[] p = { width / 2.0f, height / 2.0f };
            float[] u = { uX, uY };
            float[] q = Helper.GetIntercept(width, height, p, u);
            List<string> sideNameList = Helper.GetSideNameList(width, height, q);

            while (times > 0)
            {
                foreach(string sideName in sideNameList)
                {
                    u = Helper.GetReflectedVector(sideName, u);
                }
                q = Helper.GetIntercept(width, height, q, u);
                sideNameList = Helper.GetSideNameList(width, height, q);
                times--;
            }

            foreach (string sideName in sideNameList)
            {
                Console.WriteLine(sideName);
            }
            Console.Read();
        }
    }
}
