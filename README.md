CENTRO UNIVERSITÁRIO UNIMA | AFYA

CURSO DE CIÊNCIA DA COMPUTAÇÃO






           CHALLENGE OF DESTINY - LAA



                           

                                       
Héber Araujo
Marcelo Eugênio
Lucas Gaia
Gustavo Nogueira
Rafel Antônio






Maceió/AL
Agosto/2024



1. Introdução

Em Challenge of Destiny, o jogador embarca em uma jornada 2D cheia de perigos, explorando diversos mapas enquanto tenta completar missões desafiadoras. Cada mapa está repleto de inimigos determinados a impedir seu progresso, mas com habilidades como o uso de espada e poderes especiais, o jogador deve derrotá-los. O objetivo principal é encontrar os itens necessários para cada missão e escapar do mapa com vida.

2. Definição de Elementos do Jogo
O jogo usa a biblioteca Pygame para renderizar os gráficos, com um contexto 2D onde elementos como o jogador, inimigos e itens coletáveis ganham vida. Na tela o jogador recebe as informações muito claras de suas missões, mostrando os itens coletáveis em tempo real, essencial para o sucesso nas missões de coleta e sobrevivência.

3. Personagem Principal 
O protagonista do jogo, controlado pelo jogador com atributos como: tamanho, vida, poder e velocidade ajustáveis, que permitem ao jogador explorar o mapa e evitar perigos. O inventário coleta itens essenciais para avançar no jogo. Controlado por teclas, o movimento do personagem é preciso. Animações suaves tornam a experiência mais imersiva, enquanto o jogador enfrenta inimigos e busca itens no mapa.

4. Inimigos e Spawn 
Os inimigos surgem em posições distantes do jogador, garantindo um desafio equilibrado desde o início. Eles se movem em direção ao jogador com base em uma lógica de perseguição, ajustando sua velocidade conforme o nível de dificuldade. À medida que o jogador avança pelas fases, os inimigos se tornam mais inteligentes, aprendendo a evitar obstáculos e até cooperando para encurralar o personagem. Esses comportamentos estratégicos aumentam o desafio e exigem que o jogador use não apenas sua espada, mas também seus poderes para sobreviver.
4. Feedback visual e Reinício
Em caso de derrota, o jogo é reiniciado automaticamente após uma derrota, com o jogador retornando à fase inicial e com um inventário vazio. O feedback visual e sonoro é projetado para criar uma experiência emocional impactante, incentivando o jogador a tentar novamente e superar o desafio.

5. Executável e no Git
O jogo foi desenvolvido para ser acessível através de um executável, para ser instalado nas máquinas dos usuários. O código-fonte foi versionado e publicado no GitHub, permitindo colaborações e melhorias contínuas.
