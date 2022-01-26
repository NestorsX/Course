using System;
using System.IO;
using System.Threading;

namespace TrackingStreamConsole
{
    public class TrackingStream : Stream
    {
        public event EventHandler<TrackingStreamEventArgs> Notify;
        private readonly Stream _stream;

        public TrackingStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            _stream = stream;
        }
        public override bool CanRead => _stream.CanRead;

        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public override void Flush()
        {
            _stream.Flush();
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

            int part = count / 10;
            int value = 0;
            while (count != 0 && value != Length)
            {
                if (part > count)
                {
                    part = count;
                }

                value += _stream.Read(buffer, offset, part);
                OnPartOfFileIsRead(new TrackingStreamEventArgs { Length = Length, Value = value });
                offset += part;
                count -= part;
            }

            return value;
        }

        private void OnPartOfFileIsRead(TrackingStreamEventArgs e)
        {
            EventHandler<TrackingStreamEventArgs> handler = Notify;
            Thread.Sleep(500);
            handler?.Invoke(this, e);
        }

        public override void Close()
        {
            _stream.Close();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }
    }

    public class TrackingStreamEventArgs : EventArgs
    {
        public long Length { get; set; }
        public int Value { get; set; }
    }
}
