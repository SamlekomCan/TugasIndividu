using System;
using System.Collections.Generic;

namespace Tugas1
{
    class Program
    {

        private static int[] id;
        private static int jml;
        private static int bayar;
        private static int total = 0;
        private static List<Barang> barang = new List<Barang>();
        private static Electronic bElectronic = new Electronic();
        private static Electronic bElectronic2 = new Electronic();
        static void Main(string[] args)
        {
            bElectronic.nama = "Handphone";
            bElectronic.harga = 10000;
            _ = bElectronic.jenisBarang;

            bElectronic2.nama = "Computer";
            bElectronic2.harga = 500000;
            _ = bElectronic2.jenisBarang;

            barang.Add(bElectronic);
            barang.Add(bElectronic2);

            menu1();

        }

        public static void menu1()
        {
            Console.WriteLine("\t\t\t Aplikasi Pembelian Barang");
            Console.WriteLine("\t\t===========================================\n\n\n");
            Console.WriteLine("\t\t\t\t List Barang");
            Console.WriteLine("\t\t===========================================\n");
            tampilBarang();
            Console.WriteLine("\t\t===========================================\n");
            Console.WriteLine("Pili Menu = ");
            Console.WriteLine("1. Pembelian");
            Console.WriteLine("2. Daftar Barang");
            Console.WriteLine("3. History Pembelian");
            Console.WriteLine("4. History Baru");
            Console.WriteLine("5. Keluar");
            try
            {
                int m = int.Parse(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        pembelian();
                        Console.ReadLine();
                        Console.Clear();
                        menu1();
                        break;

                    case 2:
                        Console.Clear();
                        menu2();
                        break;
                    case 3:
                        historyPembelian();
                        Console.Clear();
                        menu1();
                        break;
                    case 4:
                        Console.Clear();
                        history();
                        Console.ReadLine();
                        Console.Clear();
                        menu1();
                        break;
                    case 5:
                        Console.WriteLine("\n\n\t\tSAMPAI JUMPA");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Maaf format salah");
            }
        }

        public static void menu2()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t List Barang");
            Console.WriteLine("\t\t===========================================\n");
            tampilBarang();
            Console.WriteLine("\t\t===========================================\n");
            Console.WriteLine("Pili Menu = ");
            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Update Barang");
            Console.WriteLine("3. Hapus barang");
            Console.WriteLine("4. Kembali");

            try
            {
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.Clear();
                        tambahBarang();
                        menu2();
                        break;
                    case 2:
                        Console.Clear();
                        updateBarang();
                        menu2();
                        break;
                    case 3:
                        Console.Clear();
                        hapusBarang();
                        menu2();
                        break;
                    case 4:
                        Console.Clear();
                        menu1();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Maaf format salah");
                menu1();
            }
        }
        //Method
        public static void history()
        {
            if (jml == 0)
            {
                Console.WriteLine("\t\tHISTORY KOSONG");
                Console.WriteLine("\t\t========================");
            }
            else
            {
                for (int i = 0; i < id.Length; i++)
                {
                    Console.WriteLine("No-" + (i + 1) + " Nama Barang : " + barang[(id[i])].nama + " Harga : " + barang[(id[i])].harga);
                }
            }
        }

        public static void tampilBarang()
        {
            for (int i = 0; i < barang.Count; i++)
            {
                Console.WriteLine("\t\t" + (i) + ". Nama Barang: {0}, Harga: {1}, Jenis: {2}\n",
                    barang[i].nama, barang[i].harga, barang[i].jenisBarang = (new Electronic().jenisBarang));
            }
            //NOTE
            Console.WriteLine("\t\tPENTING!!!");
            Console.WriteLine("\t\tBARANG DENGAN ID-{0} {1}", 1, barang[1].Tampil());
        }

        public static void updateBarang()
        {
            Console.WriteLine("ID Barang: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Harga :");
            int newH = int.Parse(Console.ReadLine());
            barang[id].harga = newH;
            Console.Clear();
            tampilBarang();
        }

        public static void hapusBarang()
        {
            Console.WriteLine("ID Barang yang akan dihapus :");
            int id = int.Parse(Console.ReadLine());
            barang.RemoveAt(id);
            Console.Clear();
            tampilBarang();
        }
        public static void tambahBarang()
        {
            Electronic jB = new Electronic();
            Console.Write("Masukkan Nama Barang: ");
            jB.nama = Console.ReadLine();
            Console.WriteLine("Masukkan Harga Barang: ");
            jB.harga = int.Parse(Console.ReadLine());
            _=  jB.jenisBarang;

            barang.Add(jB);
            Console.Clear();
            tampilBarang();
        }
        public static double totalHarga(int jHarga)
        {
            int nom = (jHarga);
            total += nom;
            return total;
        }
        public static void refund(int bayar, int total)
        {
            int kembali;
            kembali = bayar - total;

            if (bayar < total)
            {
                Console.WriteLine("Maaf, uang anda kurang !!");
                Console.WriteLine("-------------------------");
            }
            else
            {
                Console.WriteLine("\nUang kembalian anda Rp. " + kembali + ",00");
            }
        }
        public static void pembelian()
        {
            do
            {
                Console.Write("\nMasukkan jumlah barang: ");
                try
                {
                    jml = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Salah");
                }

            } while (jml < 1);

            id = new int[jml];
            for (int i = 0; i < jml; i++)
            {
                do
                {
                    Console.Write("\nMasukkan ID barang Ke-{0}: ", (i + 1));
                    id[i] = int.Parse(Console.ReadLine());
                } while (id[i] < 0);
            }
            Console.WriteLine("\n\nBarang yang dibeli");
            Console.WriteLine("=============================");

            for (int i = 0; i < jml; i++)
            {
                Console.WriteLine((i) + ". " + barang[(id[i])].nama + "   " + barang[(id[i])].harga);
                total = (int)totalHarga(barang[(id[i])].harga);
            }
            Console.WriteLine("TOTAL HARGA: {0} ", total);
            do
            {
                Console.Write("\n\nUang Bayar : ");
                bayar = int.Parse(Console.ReadLine());

                refund(bayar, total);

            } while (bayar < total);

            Console.WriteLine("\n\n\t\t^_^ Terimakasih telah berbelanja di toko kami ^_^");

        }
        public static void historyPembelian()
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (id.Length == 0)
                {
                    Console.WriteLine("Maaf History Kosong");

                }
                else if (id.Length > 0)
                {
                    Console.WriteLine("\t\tHISTORY");
                    Console.WriteLine("\t\t====================");
                    Console.WriteLine("\t\tNo-" + (i + 1) + " Nama Barang : " + barang[(id[i])].nama + " Harga : " + barang[(id[i])].harga);
                }
            }
        }
    }
}