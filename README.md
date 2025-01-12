# Sodagreen_album_index

Ce projet est un index des albums du groupe taïwanais Sodagreen. Il permet de charger des données au format `json` ou `csv`, de les extraire directement depuis Wikipédia, ou encore d’ajouter des titres manuellement. Les données peuvent ensuite être sauvegardées au format `txt` ou `json`.

## Donné et prétraitement

Les données sont collectées depuis le site wikipedia et normalisées à l’aide d’un script Python. Dans le répertoire `data`, les fichiers `titres.json` et `titres.csv` sont des fichiers normalisés, et les fichiers `albums.csv` et `albums.json` ne respectent pas le format attendu par le programme. Par conséquent, une exception sera levée lors de leur utilisation.

## Commandes

- `help` :  
  Affiche la liste de toutes les commandes disponibles dans le programme.

- `changelang/切换语言` :  
  Permet de changer la langue du programme. Les options disponibles sont `en` (anglais) et `zh` (chinois).

- `addsong` :  
  Ajoute un titre manuellement. Suivez les indications pour saisir correctement les informations du titre.

- `loadjson` : `fichier.json`  
  Charge des données à partir d’un fichier au format json.

- `savejson` : `fichier.json`  
  Sauvegarde les titres actuels dans un fichier au format json.

- `loadcsv` : `fichier.csv`  
  Charge des données à partir d’un fichier au format csv.

- `savetxt` : `fichier.txt`  
  Sauvegarde les titres actuels dans un fichier au format txt.

- `list` :  
  Affiche la liste de tous les titres enregistrés.

- `search` :  
  Recherche des titres dans les données. Les critères disponibles sont `title` , `album`, `lyricist` et `composer` .

- `webscrape` :  
  Récupère des données depuis Wikipédia (fonctionnalité en cours d’amélioration).

- `exit` :  
  Quitte le programme.