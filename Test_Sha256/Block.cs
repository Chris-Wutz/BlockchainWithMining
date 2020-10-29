using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Sha256
{
    public class Block
    {
       private readonly long timestamp = new DateTime(1990, 3, 4).Ticks;

        public Block(string data, int blocknumber)
        {
            this.data = data;
            blockNo = blocknumber;
        }

        public int blockNo { get; set; }
        public int nonce { get; set; } = 0;
        public string data { get; set; }
        public Block next_Block { get; set; }
        public Block previous_Block { get; set; }
        public string block_hash { get; set; }

        public void addNewNext(Block newBlock)
        {
            if (next_Block == null)
            {
                next_Block = newBlock;
                next_Block.previous_Block = this;
                Console.WriteLine(ToString());
            }
            else
            {
                next_Block.addNewNext(newBlock);
            }
        }

        public string hash(bool toString)
        {
            var hexString = string.Empty;
            if (previous_Block != null)
                hexString = Encryption.SHA256HexHashString(
                    nonce + data + previous_Block.block_hash + timestamp + blockNo, toString);
            else
                hexString = Encryption.SHA256HexHashString(nonce + data + timestamp + blockNo, toString);
            return hexString;
        }

        public override string ToString()
        {
            return
                $"Block Hash: {hash(true)} \nBlockNo: {blockNo} \nBlock Data: {data} \nHashes: {nonce}\n---------------";
        }
    }
}
