import { useState } from "react";
import { useCreatePost } from "@/hooks/useCreatePost";
import { useUserStore } from "@/store/userStore";

export function useNewPost() {
  const [content, setContent] = useState("");
  const { selectedUser } = useUserStore();
  const mutation = useCreatePost();

  const handleSubmit = () => {
    if (!selectedUser || content.trim() === "" || content.length > 777) return;
    
    mutation.mutate(content, {
      onSuccess: () => setContent(""), 
    });
  };

  return {
    content,
    setContent,
    handleSubmit,
    isPosting: mutation.isPending, 
    selectedUser,
  };
}
