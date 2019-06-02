using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
   public class Program
    {
        const int n = 11;
        const int k = 10;
        public class item
        {
            public int s, c, v;
            public item(int s, int c, int v)
            {
                this.s = s;
                this.c = c;
                this.v = v;
            }
        };
        item[] graph = new item[] { new item(1,2,3), new item(1,3,2), new item (2,4,5), new item(2,5,2), new item(3,6,1), new item(6,5,6), new item(5,7,3), new item(7,10,8), new item(6,8,3), new item(8,9,4)
        };
        int[] road = new int[n];
        bool[] incl = new bool[n];
        int[] way = new int[n];
        int waylen;
        int start, finish;
        bool found;
        int len;
        int c_len;
        bool fr = false;
        int find(int s, int c)
        {
            for (int i = 0; i < k; i++)
                if (graph[i].s == s && graph[i].c == c ||
                   graph[i].s == c && graph[i].c == s) return graph[i].v;
            return 0;
        }
        void step(int s, int f, int p)
        {
            int c;
            if (s == f)
            {
                found = true;
                len = c_len;
                waylen = p;
                for (int i = 0; i < waylen; i++) way[i] = road[i];
            }
            else
            {
                for (c = 0; c < n; c++)
                {
                    int w = find(s, c);
                    if ((w != 0) && !incl[c] && (len == 0 || c_len + w < len))
                    {
                        road[p] = c;
                        incl[c] = true;
                        c_len += w;
                        step(c, f, p + 1);
                        road[p] = 0;
                        incl[c] = false;
                        c_len -= w;
                    }
                }
            }
        }
        int ways(int st, int fin)
        {
            //Инициализация данных:
            for (int i = 0; i < n; i++)
            {
                road[i] = way[i] = 0; incl[i] = false;
            }
            len = c_len = waylen = 0;
            start = st;
            finish = fin;
            road[0] = start;
            incl[start] = true;
            found = false;
            step(start, finish, 1);
            return len;
        }


        static void Main(string[] args)
        {
            //Program obj = new Program();
            //int result;
            //result = obj.ways(1, 7);
            //createMessage(result);

        }

        public static int createMessage()
        {
            Program obj = new Program();
            int result = obj.ways(1, 7);
            return result;
        }
    }
}
