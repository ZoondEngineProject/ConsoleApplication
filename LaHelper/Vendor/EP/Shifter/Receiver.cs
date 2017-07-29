using System.Text;

namespace Console.Vendor.EP.Shifter
{
    class Receiver
    {
        public byte[] InputBytes;

        public string DesinflatedPacket;
        public int InputRec;

        public Receiver()
        {
            InputBytes = new byte[1024];
        }

        public void Receive(int rec)
        {
            InputRec = rec;
            Desinflate();
        }

        private void Desinflate()
        {
            DesinflatedPacket = Encoding.UTF8.GetString(InputBytes, 0, InputRec);
        }
    }
}
