AR Printer 📱🖨️
AR Printer è un progetto di tesi realizzato per supportare la manutenzione di una stampante tramite un sistema di realtà aumentata markerless.

🎯 Obiettivo
Guidare l'utente passo-passo nella manutenzione hardware di una stampante attraverso elementi in realtà aumentata (immagini/video/modelli 3D) utilizzando la tecnologia Unity's AR Foundation-AR Core.

🛠️ Tecnologie Utilizzate
⦁	Unity3D.
⦁	AR Foundation & ARCore.
⦁	C#.
⦁	Node.js + Express.js.
⦁	JavaScript.
⦁	SQLite.

🚀 Funzionalità
⦁	Riconoscimento markerless della stampante ed un mappamondo come secondo oggetto.
⦁	Sovrapposizione AR di istruzioni e animazioni.
⦁	Backend leggero per gestione contenuti e dati.

📄 Stato del progetto
Completato come progetto di tesi – prototipo funzionante

⚙️ Avvio del progetto
1.	Clona il repository.
2.	Apri il progetto in Unity3D.
3.	Installa AR Foundation e ARCore da Package Manager.
4.	Build su dispositivo Android compatibile con ARCore.

⚙️ Per avviare il web server, bisogna:
1. Installare Node.js.
2. Creare un progetto npm vuoto, con il comando 'npm init'.
3. Installare Express.js, con il comando 'npm install express'.
4. Installare SQLite, con il comando 'npm install sqlite3'.
5. Installare md5, con il comando 'npm install md5'.
6. Posizionarsi nella directory node-express ed eseguire il comando 'npm run start'; il server ascolterà le richieste sulla porta 8000.

Durante l'esecuzione dello script, se le tabelle sono già create, andrà a dropparle (per applicare eventuali modifiche apportate) quindi bisogna rilanciare lo script,  ctrl+c -> S -> npm run start.

Nello script UpdateScript in Assets/Resources/Scripts alla riga 371 e 400, e nello script ShowStats alla riga 45, è codificato l'ip da modificare a seconda dell'host    del web server (ricordarsi di aprire la porta 8000).

