public partial class StarPillar
{
    private struct Face
    {
        public int[] dot;
        public void Dot3Set(int dot1, int dot2, int dot3)
        {
            dot[0] = dot1;
            dot[1] = dot2;
            dot[2] = dot3;
        }

        public bool DotInclude(int find)
        {
            bool include = false;
            for (int i = 0; i < dot.Length; i++)
            {
                if (dot[i] == find)
                {
                    include = true;
                    break;
                }
            }
            return include;
        }

        public int[] ExceptThis(int except)
        {
            int[] returns = new int[2];
            for (int i = 0; i < 2; i++)
            {
                returns[i] = -1;
            }
            for (int i = 0; i < 3; i++)
            {
                if (dot[i] != except)
                {
                    if (returns[0] == -1)
                    {
                        returns[0] = dot[i];
                    }
                    else
                    {
                        returns[1] = dot[i];
                    }
                }
            }
            return returns;
        }

        public int[] FirstThis(int first)
        {
            int[] returns = new int[2];
            if (dot[0] == first)
            {
                returns[0] = dot[1];
                returns[1] = dot[2];
                
            }
            if (dot[1] == first)
            {
                returns[0] = dot[2];
                returns[1] = dot[0];
            }
            if (dot[2] == first)
            {
                returns[0] = dot[0];
                returns[1] = dot[1];
            }
            return returns;
        }
    }
}