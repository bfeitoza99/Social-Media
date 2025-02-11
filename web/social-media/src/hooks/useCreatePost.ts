import { createPost } from "@/services/post-service";
import { useUserStore } from "@/store/userStore";
import { APIError } from "@/type/api/error";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "react-hot-toast";

export function useCreatePost() {
  const queryClient = useQueryClient();

  const { selectedUser } = useUserStore();

  return useMutation({
    mutationFn: async (content: string) => {
          if (!selectedUser) throw new Error("No user selected");
          return createPost({ content, authorUserId: selectedUser.id });
        }, 
    onSuccess: () => {
        toast.dismiss("post-success"); 
        toast.success("Your post has been created!", { id: "post-success" });
      queryClient.refetchQueries({ queryKey: ["posts"] });
    },
    onError: (error: APIError) => {
        toast.dismiss("post-error"); 

        const errorMessage = error?.response?.data?.message || error.message;
        toast.error(errorMessage, { id: "post-error" });
    },
  });
}
