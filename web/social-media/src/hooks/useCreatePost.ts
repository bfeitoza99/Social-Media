import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

const API_URL = "http://localhost:5099/api/Post";

async function createPost(newPost: { content: string; authorUserId: number }) {
  await axios.post(API_URL, newPost);
}

export function useCreatePost() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: createPost,
    onSuccess: () => {
      queryClient.invalidateQueries(); 
    },
  });
}
