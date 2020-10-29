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
            var blockchain = new Blockchain();
            for (var i = 0; i <= 10; i++) blockchain.mine(new Block("Block" + (i + 1), i + 1));

            //Console.WriteLine();
            //Console.WriteLine("-------------------------");
            //Console.WriteLine();

            //blockchain.showAllBlocks(blockchain.block);

            Console.ReadKey();
        }
    }
}
