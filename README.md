# TicTacToe
TicTacToe Game
Versão: 1.0

Autor: Pedro Henrique Eugenio de Medeiros

Email: pedro.medeiros.001@acad.pucrs.br

## Manual de utilização para disputar uma partida no TicTacToe Game

### Pré-Requisitos:
* .Net 6.0 ou superior
* Terminal por linha de comando para execução do código

### Regras do Jogo:
* O jogo é disputado entre 2 (dois) jogadores em um tabuleiro 3x3.
* Os turnos de jogada são alternados entre os jogadores.
* O primeiro jogador será representado pelo símbolo 'X'.
* O segundo jogador será representado pelo símbolo 'O'.
* O primeiro jogador a completar uma linha na horizontal, vertical ou diagonal com seu símbolo ganhará a partida, caso não haja mais posições disponíveis no tabuleiro o jogo terminará empatado.

### Inicializando o jogo:
Abra o cmd de sua preferência na raíz do projeto previamente baixado; Em seguida, utilize o comando 'dotnet run' para iniciar o game.

### Comandos do jogo:
O único comando presente no jogo é a inserção das coordenadas da posição em que o jogador da vez quer marcar com o seu símbolo, como por exemplo: '1 1'

!!Apenas posições sem marcação serão aceitas, caso a posição informada já esteja com o símbolo de algum jogador, uma nova posição será solicitada ao jogador!!

!!Qualquer inserção que fuja deste padrão o jogo informará que a jogada não foi realizada e pedirá um novo comando para o mesmo jogador!!

### Workflow
* Ao inicializar uma partida, será exibido o desenho do tabuleiro vazio com as coordenadas de suas posições, pedindo para o Jogador 1 informar a primeira posição desejada.
* Toda posição válida informada à partir deste momento irá ser marcada no tabuleiro, que será redesenhado e exibido aos jogadores E;
* Será solicitado para o próximo jogador a nova posição desejada.
* Ao terminarem as posições disponíveis (sem símbolos de jogadores) ou ao ser confirmada a premissa de definição de um vencedor, o jogo irá exibir o tabuleiro em seu estado final e em seguida o resultado final da partida.
