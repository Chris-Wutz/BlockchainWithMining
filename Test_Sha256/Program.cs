using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Test_Sha256
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain blockchain = new Blockchain();
            for (int i = 0; i < 10; i++)
            {
                blockchain.mine(new Block("Block" + (i + 1)));
            }

            while(blockchain.block.next_Block != null)
            {
                Console.WriteLine(blockchain.block.ToString());
                blockchain.block = blockchain.block.next_Block;
            }

            Console.ReadKey();
        }


    }
}
