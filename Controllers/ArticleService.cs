// ArticleService.cs

using sarel.Models; // Ensure this namespace matches where your Article class is defined
using System.Collections.Generic;

public class ArticleService
{
    private List<Article> _articles; // Simulated data store; replace with actual database access

    public ArticleService()
    {
        _articles = new List<Article> {


            new Article
{
    Id = 1,
    Title = "Obudowy SAREL - SPACIAL 3D",
    Date = DateTime.Now.AddDays(-5),
    Text = @"Firma SAREL posiada w swojej ofercie obudowy typu SAREL Spacial 3D:<br>
             - z drzwiami pełnymi, bez płyty montażowej,<br>
             - z drzwiami pełnymi i płyta pełną,<br>
             - z drzwiami przezroczystymi, bez płyty montażowej,<br><br>
             w 41 rozmiarach. Stopień ochrony wynosi IP66 (IP55 dla obudów z drzwiami podwójnymi), zgodność ze standardem EN 50298.<br><br>
             Obudowy SAREL Spacial 3D mogą być dostarczane na życzenie:<br>
             - w innych kolorach,<br>
             - z zamontowanymi akcesoriami,<br>
             - specjalnie obronione maszynowo,<br>
             - w innych wymiarach,<br>
             - z innym wykończeniem (pokryte chromianem cynku, metalizowane, itp.),<br>
             - w konfiguracjach na życzenie.<br>",
    ImageUrl = "/images/3D.jpg"
}, 
        new Article
        {
            Id = 2,
            Title = "SAREL - Wentylatory IP20",
            Date = DateTime.Now.AddDays(-255),
            Text = @"Swobodny przepływ bez fi ltra i kratki: 170 m3/h.
            Dostępne dwa modele w zależności od napięcia zasilania: 230 i 115V, 50-60Hz.
        Wyposażenie dodatkowe: kratka wylotowa (ABS, w kolorze czarnym) oraz fi ltr (czarna pianka poliuretanowa).<br>",
            ImageUrl = "/images/23D.jpg"
        } };

}

    public List<Article> GetAllArticles()
    {
        return _articles;
    }

    public Article GetArticleById(int id)
    {
        return _articles.FirstOrDefault(a => a.Id == id);
    }
}

