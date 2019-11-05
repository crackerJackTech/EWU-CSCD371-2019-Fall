using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Stream { get; }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public DataLoader(Stream source)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        {
            Stream = source ?? throw new ArgumentNullException(nameof(source));
        }



        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            Stream.Position = 0;

            using var reader = new StreamReader(Stream, leaveOpen: true);
            try
            {
                string? jsonData;

                while ((jsonData = reader.ReadLine()) != null)
                {

                    mailboxes.Add(JsonConvert.DeserializeObject<Mailbox>(jsonData));
                }

            }

            catch (JsonReaderException)
            {
                return null;
            }

            reader.Dispose();
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            if (mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }

            Stream.Position = 0;
            using var writer = new StreamWriter(Stream, leaveOpen: true);

            foreach (Mailbox mailbox in mailboxes)
            {
                writer.WriteLine(JsonConvert.SerializeObject(mailbox));
            }


            writer.Dispose();

        }

        #region IDisposable Support
        private IDisposable DisposableMember { get; }
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposableMember?.Dispose();
                }

                disposedValue = true;
            }
        }

        ~DataLoader()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
