#variant for python
#requires https://github.com/Rapptz/discord.py

import discord 
import asyncio
import re
import os.path


client = discord.Client()
pattern = re.compile('^#\d+$')

@client.event
async def on_ready():
    print('Logged in as')
    print(client.user.name)
    print(client.user.id)
    print('------')

@client.event
async def on_message(message):
	words = message.content.split(' ')
	for word in words:
		if pattern.match(word):
			number = word.replace('#', '')
			await client.send_message(message.channel, 'https://github.com/HearthSim/Hearthstone-Deck-Tracker/pull/' + number)

if os.path.exists('token.txt'):
	client.run(open('token.txt'))
else:
	client.run(input('Please input token: '))
