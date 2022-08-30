namespace GestioneSagre.Tools.Enums;

public enum MovimentoCassaTipo
{
    /// <summary>
    /// Azione movimento: aggiunge
    /// </summary>
    [Display(Name = "Fondo cassa")]
    FondoCassa,

    /// <summary>
    /// Azione movimento: aggiunge
    /// </summary>
    [Display(Name = "Incassi")]
    Incassi,

    /// <summary>
    /// Azione movimento: aggiunge
    /// </summary>
    [Display(Name = "Altri incassi")]
    AltriIncassi,

    /// <summary>
    /// Azione movimento: toglie
    /// </summary>
    [Display(Name = "Prelievi")]
    Prelievi,

    /// <summary>
    /// Azione movimento: toglie
    /// </summary>
    [Display(Name = "Spese")]
    Spese,

    /// <summary>
    /// Azione movimento: toglie
    /// </summary>
    [Display(Name = "Scontrini da incassare")]
    ScontriniDaIncassare
}