# Guideline Stratégie Git pour le Repo Design

1. **Créer une branche avec l'épic ou la story (dépendant de la taille de la story) :**
    - Exemple : `feature/pail-32`.
    - Commande: `git checkout -b feature/pail-32`
    - Respecter la nomenclature en préfixant le numéro du ticket Jira (ici PAIL-32) par `feature/` ou par `hotfix/` dans le cas d’un bugfix.


2. **A partir de cette branche, créer une branche pour chaque story (dans le cas d’une épique) ou chaque sous-tâche (dans le cas d’une story) et la checkout.**
    - Exemple : `feature/pail-38--select`
    - Commande: `git checkout -b feature/pail-38--select`


3. **Quand cette sous-branche est terminée (contenu commité), avant de push sur le repo :**
    - Retourner sur la branche parent (ici `feature/pail-32`)
        - Commande : `git checkout feature/pail-32`
    - Une fois sur la branche `feature/pail-32`, s’assurer que la branche est bien à jour avec le repo.
        - Commande : `git reset –hard origin/feature/pail-32` suivi de la commande `git pull`
    - Une fois la branche parent à jour, revenir sur la sous-branche (ici `feature/pail-38--select`)
        - Commande : `git checkout feature/pail-38--select`
    - Une fois sur la sous-branche, rebase la branche parent afin d’avoir en permanence un historique à jour par rapport à la branche parent (`ici feature/pail-32`)
        - Commande : `git rebase feature/pail-32` ou `git rebase -i feature/pail-32` (pour un rebase interactif)
    - Force push la branche dans le repo afin d’ouvrir une pull request
        - Commande : `git push -f`


4. Répéter l’étape 3 autant de fois que de changements auront été faits avant d’être push sur le repo. Ceci afin d’être à jour avec l’historique de la branche parent (`feature/pail-32`) dans le cas où une personne aurait mergé une autre branche entre temps.


5. Une fois la sous-branche (`feature/pail-38--select`) validée dans une PR, celle-ci sera mergée dans la branche parent (`feature/pail-32`).
