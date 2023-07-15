namespace Entities.Exceptions
{
    //sealed=bunu zırhlıyorum. kalıtılması mümkün olmayacak
    public sealed class BookNotFoundException : NotFoundException
    {
        //hile yapalım base class string bekliyor biz de BookNotFound burda int aldık base e string gönderdik
        public BookNotFoundException(int id) : base($"The book with id:{id} could not found.")
        {
        }
    }
}
