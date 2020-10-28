using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Sha256
{
    public class Block
    {
        private long timestamp = DateTime.Now.Ticks;
        public int blockNo { get; set; } = 0;
        public int nonce { get; set; } = 0;
        public string data { get; set; }
        public Block next_Block { get; set; } = null;
        public Block previous_Block { get; set; } = null;
        public string block_hash { get; set; }
        public Block(string data)
        {
            this.data = data;
        }

        public void addNewNext(Block newBlock)
        {
            if(this.next_Block == null)
            {
                next_Block = newBlock;
            }
            else
            {
                this.next_Block.addNewNext(newBlock);
            }
        }

        public string hash(bool toString)
        {
            string hexString = String.Empty;
            if (previous_Block != null)
                hexString = Encryption.SHA256HexHashString(nonce + data + previous_Block.block_hash + timestamp + blockNo, toString);
            else
                hexString = Encryption.SHA256HexHashString(nonce + data + timestamp + blockNo, toString);
            return hexString;
        }

        public override string ToString()
        {
            return $"Block Hash: {hash(true)} \n BlockNo: {blockNo} \n Block Data: {data} \n Hashes: {nonce} \n---------------";
        }
    }
}
