# Tirocinio
 Repository attività di tirocinio e tesi. Questo progetto permette l'aumentazione di due oggetti, una stampante ed un mappamondo, mostrando elementi in realtà aumentata (immagini/video/modelli 3D) utilizzando la tecnologia Unity's AR Foundation-AR Core. È stato utilizzato un approccio client-server, il client è stato sviluppato tramite Unity, mentre il server è stato realizzato tramite Node.js/Express.js. Per la memorizzazione dei dati è stato utilizzato SQLite come DBMS, per creare un semplice DB relazionale.

 Per avviare il web server, bisogna:
 1) installare Node.js
 2) creare un progetto npm vuoto, con il comando 'npm init'
 3) installare Express.js, con il comando 'npm install express'
 4) installare SQLite, con il comando 'npm install sqlite3'
 5) installare md5, con il comando 'npm install md5'
 6) posizionarsi nella directory node-express ed eseguire il comando 'npm run start'; il server ascolterà le richieste sulla porta 8000.

 Durante l'esecuzione dello script, se le tabelle sono già create, andrà a dropparle (per applicare eventuali modifiche apportate) quindi bisogna rilanciare lo script,  ctrl+c -> S -> npm run start

 Nello script UpdateScript in Assets/Resources/Scripts alla riga 371 e 400, e nello script ShowStats alla riga 45, è codificato l'ip da modificare a seconda dell'host    del web server (ricordarsi di aprire la porta 8000).
