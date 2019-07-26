A. Hello (ConversationNode)
  1. Chat (ConversationNodeLink A->B)

    B. That's nice, chat chat chat (ConversationNode)
      -> (A) Automatically (ConversationNodeLink B->A, no text)
  2. Ask about quest (ConversationNodeLink A->C)

    C. Here's that thing you need (ConversationNode, w/ StateChange)
        -> (A) (ConversationNodeLink C->A, no text)
  3. I have a question about something (ConversationNodeLink A->D)

    D. What is it? (ConversationNode)
      1. Question about you (ConversationNodeLink D->E)

        E. I'm a person (ConversationNode)
          -> (D) (ConversationNodeLink E->D)

      2. Question about this place (ConversationNodeLink D->F)
        F. This is a place (ConversationNode)
          -> (D) (ConversationNodeLink F->D)

      3. Nevermind 
        -> (A) (ConversationNodeLink D-A)

  4. I'll be going now (ConversationNodeLink A->Null?)
    -> Exit