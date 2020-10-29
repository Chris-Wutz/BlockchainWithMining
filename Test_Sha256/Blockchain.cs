using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Sha256
{
    public class Blockchain
    {
        private static readonly int diff = 40;
        private readonly double maxNonce = Math.Pow(2, 32);
        private readonly double target = Math.Pow(2, 256 - diff);

        public Block block { get; set; } = new Block("Genesis", 0);

        public void add(Block newBlock)
        {
            if (block.next_Block == null)
            {
                block.next_Block = newBlock;
                block.next_Block.previous_Block = block;
                Console.WriteLine(block.ToString());
            }
            else
            {
                block.next_Block.addNewNext(newBlock);
            }
        }

        public void mine(Block newBlock)
        {
            for (var i = 0; i < maxNonce; i++)
            {
                var parsed = Convert.ToDouble(newBlock.hash(false));
                if (parsed <= target)
                {
                    add(newBlock);
                    //Console.WriteLine(newBlock.ToString());
                    break;
                }

                newBlock.nonce += 1;
            }
        }

        public void showAllBlocks(Block block)
        {
            if (block.next_Block != null)
            {
                Console.WriteLine(block.ToString());
                showAllBlocks(block.next_Block);
            }
            else
            {
                Console.WriteLine(block.ToString());
            }
        }
    }
}
