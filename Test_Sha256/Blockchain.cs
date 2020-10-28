using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Sha256
{
    public class Blockchain
    {
        private static int diff = 30;
        private double maxNonce = Math.Pow(2, 32);
        private double target = Math.Pow(2, 256 - diff);

        public Block block { get; set; } = new Block("Genesis");

        public void add(Block newBlock)
        {
            if (block.next_Block == null)
                block.next_Block = newBlock;
            else
            {
                block.next_Block.addNewNext(newBlock);
            }
        }

        public void mine(Block newBlock)
        {
            for(int i = 0; i < this.maxNonce; i++)
            {
                var parsed = Convert.ToDouble(newBlock.hash(false));
                if (parsed <= this.target)
                {
                    add(newBlock);
                    Console.WriteLine(newBlock.ToString());
                    break;
                }
                else
                    newBlock.nonce += 1;
            }
        }
    }
}
