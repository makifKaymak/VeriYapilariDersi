using System;
using System.Collections.Generic;

namespace VeriYapilariCalisma
{
    class Program
    {
        static void ders1(int[] bt, int indis)
        {
            if (indis >= bt.Length) return;
            Console.WriteLine(bt[indis]);
            ders1(bt, indis * 2 + 1);
            ders1(bt, indis * 2 + 2);
        }

        static int ders2(int[] bt, int indis) //binary treenin boyutunu bul
        {
            int a = 0;
            int b = 0;
            int c = indis * 2 + 1;
            if (c < bt[indis])
                a = 1 + ders2(bt, c);

            if (c + 1 < bt[indis])
                b = 1 + ders2(bt, c + 1);
            if (indis == 0)
                a++;
            return a + b;

        }

        static int ders3(int[] bt, int indis, int data) //aradağımız değer içinde var mı
        {
            if (indis >= bt.Length) return 0;
            if (bt[indis] == data) return 1;

            return ders3(bt, indis * 2 + 1, data) + ders3(bt, indis * 2 + 2, data);
        }

        static int ders4(int[] bt, int indis)
        {
            if (indis >= bt.Length) return 0;

            int a = ders4(bt, indis * 2 + 1);
            int b = ders4(bt, indis * 2 + 2);
            int c = 0;

            if (a > b) c = a;
            else c = b;
            if (bt[indis] > c) c = bt[indis];
            return c;

        }

        static int ders5(int[] bt, int indis, int data)
        {
            if (indis >= bt.Length) return 0;
            if (bt[indis] == data) return 1;
            int a = 0;

            if (data > bt[indis])
                a = ders5(bt, indis * 2 + 1, data);
            else
                a = ders5(bt, indis * 2 + 2, data);
            return a;
        }

        static void ders6(int[] bt, int indis, int data)
        {
            if (indis >= bt.Length) return;
            int a = indis * 2 + 1;
            if (bt[indis] == 0)
            {
                bt[indis] = data;
                return;
            }
            if (bt[indis] < data) a++;
            if (a >= bt.Length) return;
            if (bt[a] == 0)
            {
                bt[a] = data;
                return;
            }
            else
                ders6(bt, a, data);

        }

        static void ders7(int[] bt, int indis)
        {
            if (indis >= bt.Length) return;
            ders7(bt, indis * 2 + 1);
            if (bt[indis] != 0) Console.WriteLine(bt[indis]);
            ders7(bt, indis * 2 + 2);
        }

        class myBinaryTree
        {
            public int data;
            public myBinaryTree right;
            public myBinaryTree left;

        }

        static myBinaryTree ders8(int[] bt, int indis, ref myBinaryTree btl)
        {
            if (indis >= bt.Length) return null;
            myBinaryTree tmp = new myBinaryTree();
            tmp.data = bt[indis];
            if (btl == null)
            {
                btl = tmp;
            }
            tmp.left = ders8(bt, indis * 2 + 1, ref btl);
            tmp.right = ders8(bt, indis * 2 + 2, ref btl);
            return tmp;

        }

        static void ders9(myBinaryTree mbt)
        {
            if (mbt == null) return;
            ders9(mbt.left);
            if (mbt.data != 0) Console.WriteLine(mbt.data);
            ders9(mbt.right);
        }

        static void seviyeYazdir(int[] bt, int indis, int seviye)
        {
            if (indis >= bt.Length) return;
            if (seviye == 3)
            {
                Console.WriteLine(bt[indis]);
                return;
            }
            int a = indis * 2 + 1;
            if (a < bt.Length)
                seviyeYazdir(bt, a, seviye + 1);
            a++;
            if (a < bt.Length)
                seviyeYazdir(bt, a, seviye + 1);

        }

        static int seviyeYazdirFarkli(int[] bt, int indis, int seviye)
        {
            if (seviye == 3) return 1;
            int a = indis * 2 + 1;
            int b = 0;
            if (a < bt.Length)
                if (bt[a] != 0)
                    b = seviyeYazdirFarkli(bt, a, seviye + 1);
            a++;
            if (a < bt.Length)
                if (bt[a] != 0)
                    b += seviyeYazdirFarkli(bt, a, seviye + 1);
            return b;
        }

        static int seviyeYazdir3SeviyedekiEnbuyukEleman(int[] bt, int indis, int seviye)
        {
            if (seviye == 3)
                return bt[indis];
            int a = indis * 2 + 1;
            int b = 0;
            int c = 0;

            if (a < bt.Length && bt[a] != 0)
                b = seviyeYazdir3SeviyedekiEnbuyukEleman(bt, a, seviye + 1);
            a++;
            if (a < bt.Length && bt[a] != 0)
                c = seviyeYazdir3SeviyedekiEnbuyukEleman(bt, a, seviye + 1);

            if (b < c)
                b = c;
            return b;
        }

        static void ders11(int[] bt)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            while (stack.Count > 0)
            {
                int indis = stack.Pop();
                Console.WriteLine(bt[indis]);
                if (indis * 2 + 1 < bt.Length)
                    stack.Push(indis * 2 + 1);
                if (indis * 2 + 2 < bt.Length)
                    stack.Push(indis * 2 + 2);
            }
        }

        static int ders2Gelismis(int[] bt, int indis)
        {
            int a = 0;
            int b = 0;
            int c = indis * 2 + 1;

            if (c < bt.Length && bt[c] > 0)
                a = ders2Gelismis(bt, c);
            c++;
            if (c < bt.Length && bt[c] > 0)
                b = ders2Gelismis(bt, c);

            if (a > b) return a; else return b;
        }

        static int ders2BinaryDerinlik(myBinaryTree bt)
        {
            int a = 0;
            int b = 0;

            if (bt.left != null)
                a = 1 + ders2BinaryDerinlik(bt.left);
            if (bt.right != null)
                b = 1 + ders2BinaryDerinlik(bt.right);

            return a + b;
        }

        static int ders44(int[] bt, int indis, ref int eb1, ref int eb2)
        {
            if (indis >= bt.Length) return 0;

            ders44(bt, indis * 2 + 1, ref eb1, ref eb2);
            ders44(bt, indis * 2 + 2, ref eb1, ref eb2);

            if (bt[indis] > eb1)
            {
                eb2 = eb1;
                eb1 = bt[indis];
            }
            else if (bt[indis] > eb2)
                eb2 = bt[indis];

            return eb2;

        }

        static int ders444(int[] bt, int indis, ref int eb1, ref int eb2, ref int eb3)
        {
            if (indis >= bt.Length) return 0;

            ders444(bt, indis * 2 + 1, ref eb1, ref eb2, ref eb3);
            ders444(bt, indis * 2 + 2, ref eb1, ref eb2, ref eb3);

            if (bt[indis] > eb1)
            {
                eb3 = eb2;
                eb2 = eb1;
                eb1 = bt[indis];
            }
            else if (bt[indis] > eb2)
            {
                eb3 = eb2;
                eb2 = bt[indis];
            }
            else if (bt[indis] > eb3)
            {
                eb3 = bt[indis];
            }

            return eb3;
        }

        static int ToplamHesapla(int[] bt, int indis) //sınav sorusu gibi
        {
            if (indis >= bt.Length)
                return 0;

            return bt[indis] + ToplamHesapla(bt, indis * 2 + 1) +
                ToplamHesapla(bt, indis * 2 + 2);
        }

        class Block
        {
            public int data;
            public string hashdata;
            public Block next;
            public Block prev;
        }

        static string[,] hash = new string[100, 4];
        static string[] coll = new string[20];

        static string[] HASH = new string[100];

        static Block[] HashLinked = new Block[100];

        static string[] HashNew = new string[20];

        static string[] DictData = new string[100];

        static int HashFunction(string st)
        {
            int indis = 0;
            for (int i = 0; i < st.Length; i++)
            {
                indis = indis + st[i] - '0';
            }
            indis = indis % hash.Length;
            return indis;
        }

        static void hashEkle(string st)
        {
            int indis = HashFunction(st);
            if (hash[indis, 0] != null)
            {
                for (int i = 0; i < hash.GetLength(1); i++)
                {
                    if (hash[indis, i] == null)
                    {
                        hash[indis, i] = st;
                        break;
                    }
                }
            }
            else
                hash[indis, 0] = st;
        }

        static int HashSearch(string st)
        {
            int indis = HashFunction(st);
            int bl = 0;
            for (int i = 0; i < hash.GetLength(1); i++)
            {
                if (hash[indis, i] == st)
                {
                    bl = 1;
                    break;
                }
            }
            return bl;
        }

        static void HashDelete(string st)
        {
            int indis = HashFunction(st);

            for (int i = 0; i < hash.GetLength(1); i++)
            {
                if (hash[indis, i] == st)
                {
                    hash[indis, i] = null;
                    break;
                }
            }
        }

        static int HashFunctionNew(string st)
        {
            int indis = 0;
            for (int i = 0; i < st.Length; i++)
            {
                indis = indis + (st[i] - '0') * (i + 1);
            }
            indis = indis % 20;
            return indis;
        }

        static void HashEkleNew(string st)
        {
            int indis = HashFunction(st);

            if (HASH[indis] == null)
            {
                HASH[indis] = st;
                return;
            }
            else
            {
                for (int i = 0; i < HASH.Length; i++)
                {
                    if (HASH[i] == null)
                    {
                        HASH[i] = st;
                        break;
                    }
                }
            }
        }

        static void HashEkleLinked(string st)
        {
            int indis = HashFunction(st);
            if (HashLinked[indis] == null)
            {
                HashLinked[indis] = new Block();
                HashLinked[indis].hashdata = st;
            }

            else
            {
                //1.çözümün 'a' alternatif çözümü
                HashLinked[indis].prev = new Block();
                HashLinked[indis].prev.hashdata = st;
                HashLinked[indis].prev.next = HashLinked[indis];
                HashLinked[indis] = HashLinked[indis].prev;

                //1.çözümün 'b' alternatif çözümü

                Block temp = new Block();
                temp.hashdata = st;
                temp.next = HashLinked[indis];
                HashLinked[indis].prev = temp;
                HashLinked[indis] = temp;

                //2.çözüm

                Block temp2 = HashLinked[indis];
                while (temp2.next != null)
                    temp2 = temp2.next;

                Block bl = new Block();
                bl.hashdata = st;
                bl.prev = temp2;
                temp.next = bl;

            }
        }

        static int HashSearchLinked(string st)
        {
            int indis = HashFunction(st);
            int bulundu = 0;

            Block temp = HashLinked[indis];
            while (temp != null)
            {
                if (temp.hashdata == st)
                {
                    bulundu = 1;
                    break;
                }
                temp = temp.next;
            }
            return bulundu;
        }

        static void HashDeleteLinked(string st)
        {
            int indis = HashFunction(st);
            if (HashLinked[indis] == null) return;
            if (HashLinked[indis].next == null)
            {
                HashLinked[indis] = null;
                return;
            }
            Block onceki = null;

            while (HashLinked[indis] != null)
            {
                if (HashLinked[indis].hashdata == st)
                {
                    if (onceki == null)
                        HashLinked[indis] = onceki.next;
                    else
                        onceki.next = HashLinked[indis].next;
                    return;
                }
                onceki = HashLinked[indis];
                HashLinked[indis] = HashLinked[indis].next;
            }
        }

        static int[] queue = new int[100];

        static int front = 0;
        static int rear = -1;

        static int Count()
        {
            return rear - front + 1;
        }

        static void Enqueue(int data)
        {
            rear++;
            rear = rear % queue.Length;
            queue[rear] = data;
        }

        static int Dequeue()
        {
            int data = queue[front];
            front++;
            front = front % queue.Length;
            return data;
        }

        static void printQueue(string message)
        {
            Console.WriteLine(message);
            for (int i = front; i <= rear; i++)
            {
                Console.WriteLine(queue[i] + " ");
            }
            Console.WriteLine();
        }

        static Block FrontLL = null;
        static Block RearLL = null;

        static void EnqueueLinked(int data)
        {
            Block bl = new Block();
            bl.data = data;

            if (FrontLL == null)
            {
                FrontLL = bl;
                RearLL = bl;
                return;
            }

            bl.prev = RearLL;
            RearLL.next = bl;
            RearLL = bl;
        }

        static int DequeueLinked()
        {
            int data = FrontLL.data;
            if (FrontLL.next != null)
            {
                FrontLL.next.prev = null;
            }
            FrontLL = FrontLL.next;
            return data;
        }

        static void TekliLinkedListOlusturma()
        {
            Block head = null;
            Block last = null;

            for (int i = 0; i < 10; i++)
            {
                Block temp = new Block();
                temp.data = i;
                temp.next = null;

                if (head == null) head = temp;
                else last.next = temp;
                last = temp;
            }
        }

        static void CiftliLinkedListOlusturma()
        {
            Block head = null;
            Block last = null;

            for (int i = 0; i < 10; i++)
            {
                Block temp = new Block();
                temp.data = i;
                temp.next = null;

                if (head == null)
                {
                    head = temp;
                    last = temp;
                    temp.prev = null;
                }

                else
                {
                    temp.next = last;
                    last.prev = temp;
                    last = temp;
                }
            }
        }

        static void EklemeLinkedList(ref Block first, int data)
        {
            Block bl = new Block();
            bl.data = data;
            if (first == null)
            {
                first = bl;
                return;
            }

            Block temp = first;
            int flag = 0;

            while (data > temp.data)
            {
                flag = 1;
                if (temp.next == null)
                {
                    flag = 2;
                    break;
                }
                temp = temp.next;
            }

            if (flag == 0)
            {
                bl.next = first;
                first.prev = bl;
                first = bl;
                return;
            }

            if (flag == 1)
            {
                bl.next = temp;
                bl.prev = temp.prev;

                temp.prev.next = bl;
                temp.prev = bl;

                return;
            }

            if (flag == 2)
            {
                temp.next = bl;
                bl.prev = temp;
                return;
            }
        }

        static string[] stack = new string[100];
        static int[] stackInt = new int[100];
        static int sp = -1;

        static void Push(string data)
        {
            sp++;
            stack[sp] = data;
        }

        static void PushInt(int data)
        {
            sp++;
            stackInt[sp] = data;
        }

        static string Pop()
        {
            if (sp >= 0)
            {
                string data = stack[sp];
                sp--;
                return data;
            }
            else return null;
        }

        static int PopInt()
        {
            if (sp >= 0)
            {
                int data = stackInt[sp];
                sp--;
                return data;
            }
            else return 0;
        }

        static string Peek()
        {
            if (sp >= 0)
            {
                return stack[sp];
            }
            else return null;
        }

        static void polindromStack()
        {
            string kelime = "ey edip adanada pide ye";
            int sayac = 0;

            foreach (char karakter in kelime)
            {
                if (karakter != ' ')
                    Push(karakter.ToString());
            }

            foreach (var karakter in kelime)
            {
                if (karakter != ' ')
                {
                    if (Pop() == karakter.ToString())
                        sayac++;
                    else
                    {
                        Console.WriteLine("Bu bir palindrom sayıdır.");
                        return;
                    }
                }
            }

            if (sayac == kelime.Length - kelime.Split(' ').Length + 1)
                Console.WriteLine("Bu bir palindromdur.");
        }

        static void parantezEslesiyorMu()
        {
            string s1 = "[{()((()))}]";
            int hata = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == '[' || s1[i] == '{' || s1[i] == '(')
                    PushInt(s1[i]);
                if (s1[i] == ')')
                    if ((char)PopInt() != '(') hata = 1;
                if (s1[i] == '}')
                    if ((char)PopInt() != '{') hata = 1;
                if (s1[i] == ']')
                    if ((char)PopInt() != '[') hata = 1;

            }
            if (hata == 0) Console.WriteLine("eşleşti");
            else Console.WriteLine("eşleşmedi");
        }

        static void terstenYazdirmaStack()
        {
            string kelime = "Selamlar nasılsınız?";
            foreach (char karakter in kelime)
                Push(karakter.ToString());

            string kelimeTersten = "";

            for (int i = 0; i < kelime.Length; i++)
            {
                kelimeTersten += Pop();
            }
            Console.WriteLine(kelime);
            Console.WriteLine(kelimeTersten);
        }

        static void Main(string[] args)
        {
            int[] dizi = new int[10];

            for (int i = 0; i < 10; i++)
            {
                dizi[i] = i + 1;
            }

            Console.WriteLine(ToplamHesapla(dizi, 1));


            Console.ReadKey();
        }
    }
}

