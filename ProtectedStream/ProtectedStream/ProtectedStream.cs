using System;
using System.IO;

namespace ProtectedStream
{
    public class ProtectedStream : Stream
    {
        private readonly Stream _stream;

        private const string _password = "1234";

        public ProtectedStream(Stream stream, string password)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (password != _password)
            {
                throw new ArgumentException("Wrong password");
            }

            _stream = stream;
        }
        public override bool CanRead => throw new NotImplementedException();

        public override bool CanSeek => throw new NotImplementedException();

        public override bool CanWrite => throw new NotImplementedException();

        public override long Length
        {
            get
            {
                return _stream.Length;
            }
        }

        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("Buffer");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("Offset");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("Count");
            }

            if (buffer.Length - offset < count)
            {
                throw new ArgumentException("Count must be less or equal to length of array");
            }
            return _stream.Read(buffer, offset, count);
        }

        public override void Close()
        {
            _stream.Close();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
