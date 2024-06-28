# 3) Sort score and name of players print the top 10
def sort_and_print_top_players(players):
    players.sort(reverse=True)  
    for player in players[:10]:
        print(f'{player[1]}: {player[0]}')

