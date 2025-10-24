class BlackjackGame {
    constructor() {
        this.output = document.getElementById('output');
        this.input = document.getElementById('input');
        this.deck = [];
        this.playerHand = [];
        this.dealerHand = [];
        this.playerBalance = 10000;
        this.currentBet = 0;
        this.gameState = 'intro';
        this.playerName = 'Player';
        
        this.input.addEventListener('keydown', (e) => {
            if (e.key === 'Enter') {
                this.handleInput(this.input.value.toLowerCase());
                this.input.value = '';
            }
        });
        
        this.start();
    }
    
    start() {
        this.print('Initializing blackjack simulation....');
        setTimeout(() => {
            this.initializeDeck();
            this.showIntro();
        }, 1000);
    }
    
    print(text, color = 'white') {
        const line = document.createElement('div');
        line.style.color = color;
        line.innerHTML = text;
        this.output.appendChild(line);
        this.output.scrollTop = this.output.scrollHeight;
    }
    
    clear() {
        this.output.innerHTML = '';
    }
    
    initializeDeck() {
        const suits = ['♦', '♣', '♠', '♥'];
        const values = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'j', 'q', 'k', 'a'];
        
        this.deck = [];
        for (let suit of suits) {
            for (let i = 0; i < values.length; i++) {
                this.deck.push({
                    display: values[i] + suit,
                    value: i + 1,
                    suit: suit,
                    suitColor: (suit === '♦' || suit === '♥') ? 'red' : 'gray'
                });
            }
        }
        this.shuffleDeck();
    }
    
    shuffleDeck() {
        for (let i = this.deck.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [this.deck[i], this.deck[j]] = [this.deck[j], this.deck[i]];
        }
    }
    
    showIntro() {
        this.clear();
        this.print('<span style="color: white;">WELCOME TO </span><span style="color: red;">TYCHO\'S </span><span style="color: white;">VIRTUAL BLACKJACK CASINO!</span>');
        this.print('');
        this.print('Press ENTER to continue', 'white');
        this.gameState = 'awaiting-enter';
    }
    
    showRules() {
        this.clear();
        this.print('THE RULES:', 'yellow');
        this.print('');
        this.print('<span style="color: white;">You have </span><span style="color: yellow;">$10000 </span><span style="color: white;">to play with.</span>');
        this.print('<span style="color: white;">You can bet up to </span><span style="color: yellow;">$1000 </span><span style="color: white;">per hand.</span>');
        this.print('');
        this.print('<span style="color: white;">If you </span><span style="color: red;">lose </span><span style="color: white;">your bet is </span><span style="color: red;">lost.</span>');
        this.print('<span style="color: white;">If you </span><span style="color: green;">win </span><span style="color: white;">your bet is </span><span style="color: green;">doubled.</span>');
        this.print('');
        this.print('Use the <span style="color: yellow;">\'H\'</span> key to hit');
        this.print('Use the <span style="color: yellow;">\'S\'</span> key to stand');
        this.print('Use the <span style="color: yellow;">\'D\'</span> key to double down');
        this.print('Use the <span style="color: yellow;">\'Q\'</span> key to quit');
        this.print('');
        this.print('Press ENTER to start playing', 'white');
        this.gameState = 'awaiting-start';
    }
    
    startRound() {
        if (this.playerBalance < 10) {
            this.print('You are out of money! Game Over.', 'red');
            this.gameState = 'game-over';
            return;
        }
        
        this.playerHand = [];
        this.dealerHand = [];
        this.showGameUI();
        this.print('<span style="color: white;">It\'s </span><span style="color: green;">' + this.playerName + '\'s </span><span style="color: white;">turn!</span>');
        
        setTimeout(() => {
            this.print('<span style="color: white;">How much do you want to bet? (</span><span style="color: red;">Max $1000</span><span style="color: white;">)</span>');
            this.gameState = 'betting';
        }, 1000);
    }
    
    showGameUI() {
        this.clear();
        this.print('<span style="color: magenta;">----------------------------------------------------------------</span>');
        this.print('<span style="color: cyan;">Deck</span>');
        this.print('<span style="color: cyan;">Remaining cards in deck: ' + this.deck.length + '</span>');
        this.print('<span style="color: magenta;">----------------------------------------------------------------</span>');
        this.print('');
        this.print('<span style="color: magenta;">----------------------------------------------------------------</span>');
        this.print('<span style="color: green;">Player\'s Hand & Balance</span>');
        this.print('');
        this.print('<span style="color: magenta;">----------------------------------------------------------------</span>');
        this.print('');
        this.print('<span style="color: magenta;">----------------------------------------------------------------</span>');
        this.print('<span style="color: red;">Dealer\'s Hand</span>');
        this.print('');
        this.print('<span style="color: magenta;">----------------------------------------------------------------</span>');
        this.print('');
    }
    
    updateGameUI() {
        const deckInfo = '<span style="color: cyan;">Remaining cards in deck: ' + this.deck.length + '</span>';
        
        let playerHandText = '<span style="color: white;">';
        let playerTotal = 0;
        
        for (let card of this.playerHand) {
            playerHandText += '<span style="color: ' + card.suitColor + ';">' + card.display + '</span>, ';
            playerTotal += this.getCardValue(card, this.playerHand);
        }
        
        playerHandText += '(' + playerTotal + '), (<span style="color: yellow;">$' + this.currentBet + '</span>)</span>';
        
        let dealerHandText = '<span style="color: white;">';
        let dealerTotal = 0;
        
        if (this.gameState === 'player-turn' || this.gameState === 'initial-deal') {
            dealerHandText += '<span style="color: ' + this.dealerHand[0].suitColor + ';">' + this.dealerHand[0].display + '</span>, xX, (hidden)</span>';
        } else {
            for (let card of this.dealerHand) {
                dealerHandText += '<span style="color: ' + card.suitColor + ';">' + card.display + '</span>, ';
                dealerTotal += this.getCardValue(card, this.dealerHand);
            }
            dealerHandText += '(' + dealerTotal + ')</span>';
        }
        
        this.showGameUI();
        this.print(deckInfo);
        this.print('');
        this.print('<span style="color: green;">Player\'s Hand & Balance: $' + this.playerBalance + '</span>');
        this.print(playerHandText);
        this.print('');
        this.print('<span style="color: red;">Dealer\'s Hand</span>');
        this.print(dealerHandText);
        this.print('');
    }
    
    getCardValue(card, hand) {
        if (card.value >= 9 && card.value <= 12) {
            return 10;
        } else if (card.value === 13) {
            if (hand.length === 2) {
                return 11;
            } else {
                return 1;
            }
        } else {
            return card.value + 1;
        }
    }
    
    calculateHandValue(hand) {
        let total = 0;
        let aces = 0;
        
        for (let card of hand) {
            if (card.value >= 9 && card.value <= 12) {
                total += 10;
            } else if (card.value === 13) {
                aces++;
                total += 11;
            } else {
                total += card.value + 1;
            }
        }
        
        while (total > 21 && aces > 0) {
            total -= 10;
            aces--;
        }
        
        return total;
    }
    
    dealCard(hand) {
        if (this.deck.length === 0) {
            this.print('Shuffling deck...', 'white');
            this.initializeDeck();
        }
        const card = this.deck.pop();
        hand.push(card);
        return card;
    }
    
    initialDeal() {
        this.dealCard(this.playerHand);
        this.dealCard(this.dealerHand);
        this.dealCard(this.playerHand);
        this.dealCard(this.dealerHand);
        
        this.updateGameUI();
        
        const playerTotal = this.calculateHandValue(this.playerHand);
        
        if (playerTotal === 21) {
            this.print('<span style="color: green;">' + this.playerName + ' has Blackjack!</span>');
            this.endRound();
        } else {
            this.showActions();
            this.gameState = 'player-turn';
        }
    }
    
    showActions(canDoubleDown = true) {
        this.print('');
        if (canDoubleDown) {
            this.print('<span style="color: yellow;">Actions:</span> <span style="color: yellow;">h</span>: Hit | <span style="color: yellow;">s</span>: Stand | <span style="color: yellow;">d</span>: Double Down | <span style="color: yellow;">q</span>: Quit');
        } else {
            this.print('<span style="color: yellow;">Actions:</span> <span style="color: yellow;">h</span>: Hit | <span style="color: yellow;">s</span>: Stand | <span style="color: yellow;">q</span>: Quit');
        }
        this.print('Choose one of the actions above!', 'white');
    }
    
    playerHit() {
        this.dealCard(this.playerHand);
        this.updateGameUI();
        
        const playerTotal = this.calculateHandValue(this.playerHand);
        
        if (playerTotal > 21) {
            this.print('<span style="color: red;">' + this.playerName + ' busted!</span>');
            setTimeout(() => this.endRound(), 2000);
        } else if (playerTotal === 21) {
            this.print('<span style="color: green;">' + this.playerName + ' has 21!</span>');
            this.showActions(false);
        } else {
            this.showActions(false);
        }
    }
    
    playerStand() {
        this.gameState = 'dealer-turn';
        this.print('<span style="color: green;">' + this.playerName + ' stands.</span>');
        
        setTimeout(() => this.dealerPlay(), 2000);
    }
    
    playerDoubleDown() {
        if (this.currentBet > this.playerBalance) {
            this.print('You do not have enough money to double down!', 'red');
            this.showActions();
            return;
        }
        
        this.playerBalance -= this.currentBet;
        this.currentBet *= 2;
        
        this.print('<span style="color: white;">' + this.playerName + ' doubles down and now plays with a bet of </span><span style="color: yellow;">$' + this.currentBet + '</span>');
        
        this.dealCard(this.playerHand);
        this.updateGameUI();
        
        const playerTotal = this.calculateHandValue(this.playerHand);
        
        if (playerTotal > 21) {
            this.print('<span style="color: red;">' + this.playerName + ' busted!</span>');
            setTimeout(() => this.endRound(), 2000);
        } else {
            setTimeout(() => this.dealerPlay(), 2000);
        }
    }
    
    dealerPlay() {
        this.updateGameUI();
        
        const dealerTotal = this.calculateHandValue(this.dealerHand);
        
        if (dealerTotal > 21) {
            this.print('<span style="color: green;">Dealer busted! ' + this.playerName + ' wins!</span>');
            setTimeout(() => this.endRound(), 2000);
            return;
        }
        
        if (dealerTotal >= 18) {
            this.print('Dealer stands!', 'white');
            setTimeout(() => this.endRound(), 2000);
        } else {
            this.print('Dealer hits!', 'white');
            this.dealCard(this.dealerHand);
            setTimeout(() => this.dealerPlay(), 2000);
        }
    }
    
    endRound() {
        this.updateGameUI();
        
        const playerTotal = this.calculateHandValue(this.playerHand);
        const dealerTotal = this.calculateHandValue(this.dealerHand);
        
        let winnings = 0;
        
        if (playerTotal > 21) {
            this.print('<span style="color: red;">' + this.playerName + ' went over 21 and lost!</span>');
            winnings = 0;
        } else if (dealerTotal > 21) {
            this.print('<span style="color: green;">Dealer went over 21, ' + this.playerName + ' won!</span>');
            winnings = this.currentBet * 2;
        } else if (playerTotal === 21 && this.playerHand.length === 2) {
            this.print('<span style="color: green;">' + this.playerName + ' has Blackjack and won 3 times the bet!</span>');
            winnings = this.currentBet * 3;
        } else if (dealerTotal === 21 && this.dealerHand.length === 2) {
            this.print('<span style="color: red;">Dealer won with Blackjack!</span>');
            winnings = 0;
        } else if (playerTotal > dealerTotal) {
            this.print('<span style="color: green;">' + this.playerName + ' won with ' + playerTotal + ' points!</span>');
            winnings = this.currentBet * 2;
        } else if (playerTotal < dealerTotal) {
            this.print('<span style="color: red;">Dealer won with ' + dealerTotal + ' points!</span>');
            winnings = 0;
        } else {
            this.print('<span style="color: yellow;">Dealer and ' + this.playerName + ' tied at ' + playerTotal + ' points!</span>');
            winnings = this.currentBet;
        }
        
        this.playerBalance += winnings;
        
        if (winnings > 0) {
            this.print('<span style="color: cyan;">' + this.playerName + ' won $' + winnings + '</span>');
        }
        
        this.print('');
        this.print('<span style="color: white;">Balance: $' + this.playerBalance + '</span>');
        this.print('');
        this.print('Press ENTER to play again', 'white');
        this.gameState = 'round-end';
    }
    
    handleInput(value) {
        switch (this.gameState) {
            case 'awaiting-enter':
                this.showRules();
                break;
                
            case 'awaiting-start':
                this.startRound();
                break;
                
            case 'betting':
                const bet = parseInt(value);
                if (isNaN(bet)) {
                    this.print('Invalid input! Please enter a number.', 'red');
                } else if (bet > 1000) {
                    this.print('You can\'t bet more than $1000!', 'red');
                } else if (bet < 10) {
                    this.print('You can\'t bet less than $10!', 'red');
                } else if (bet > this.playerBalance) {
                    this.print('You do not have enough money!', 'red');
                } else {
                    this.currentBet = bet;
                    this.playerBalance -= bet;
                    this.print('<span style="color: white;">Your bet is </span><span style="color: cyan;">$' + bet + '</span><span style="color: white;">!</span>');
                    setTimeout(() => this.initialDeal(), 1000);
                }
                break;
                
            case 'player-turn':
                switch (value) {
                    case 'h':
                        this.playerHit();
                        break;
                    case 's':
                        this.playerStand();
                        break;
                    case 'd':
                        this.playerDoubleDown();
                        break;
                    case 'q':
                        this.quit();
                        break;
                    default:
                        this.print('Invalid input!', 'red');
                        this.showActions(this.playerHand.length === 2);
                }
                break;
                
            case 'round-end':
                this.startRound();
                break;
                
            case 'game-over':
                this.print('Thanks for playing!', 'white');
                break;
        }
    }
    
    quit() {
        this.clear();
        this.print('Quitting blackjack.....', 'red');
        setTimeout(() => {
            this.clear();
            this.print('Quitted blackjack successfully.', 'red');
            this.print('Final Balance: $' + this.playerBalance, 'white');
            this.gameState = 'game-over';
        }, 2000);
    }
}

window.addEventListener('DOMContentLoaded', () => {
    new BlackjackGame();
});
