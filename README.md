------------------------------------------------------------
DISCLAIMER
------------------------------------------------------------
Ho sviluppato il progetto in C# sia perché sono molto più rapido a lavorare sia con C# che con Visual Studio sia perché posso darvi un lavoro di qualità migliore seppur didattico.

Ho cercato comunque di mantenere un parallelismo con le richieste che mi avete fatto per Java, quindi, ad esempio, per l'integrazione con MySQL non ho usato degli ORM ma una semplice libreria MySQL.Data e ho replicato il funzionamento del file .properties.

Il progetto si avvia senza bisogno di installazione runtime secondari (testato su una Sandbox con Windows 11).

Le icone usate sono prese da FlatIcon, quindi per motivi commerciali è presente una finestra about.

------------------------------------------------------------
ISTRUZIONI D'USO
------------------------------------------------------------
1. All'avvio chiede le credenziali. In caso non fosse ancora connesso al db MySQL userà quelle segnate sotto le chiavi DefaultUser e DefaultPassword nel file .properties. Nello stesso file bisognerà indicare le credenziali MySQL. Una volta che il database (struttura salvata nella cartella della build) verrà importato gli utenti che potranno effettuare il login saranno presi dalla tabella user (come da richiesta secondaria).

2. Una volta loggati nella rubrica, si ha la possibilità di usare i 3 database richiesti: CSV, struttura a cartelle/file e MySQL. Possono essere cambiati dalla combobox in basso a sinistra. I pulsanti Crea, Modifica ed Elimina lavoreranno in base al tipo di DB selezionato.
