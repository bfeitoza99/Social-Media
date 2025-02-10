import { createPost } from "@/services/post-service";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "react-hot-toast";

export function useCreatePost() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: createPost,
    onSuccess: () => {
        toast.dismiss("post-success"); 
        toast.success("Your post has been created!", { id: "post-success" });
      queryClient.refetchQueries({ queryKey: ["posts"] });
    },
    onError: (error: any) => {
        toast.dismiss("post-error"); 

        const errorMessage = error?.response?.data?.message || error.message;
        toast.error(errorMessage, { id: "post-error" });
    },
  });
}
