import { useState } from "react";
import { useCreateRepost } from "@/hooks/useCreateRepost";
import { useUserStore } from "@/store/userStore";

export function usePostActions(postId: number) {
  const [isDialogOpen, setIsDialogOpen] = useState(false);

  const { selectedUser } = useUserStore();
  const { mutate: createRepost, isPending } = useCreateRepost();

  const handleConfirmRepost = () => {
    createRepost(postId);
    setIsDialogOpen(false);
  };

  return {
    isDialogOpen,
    setIsDialogOpen,
    handleConfirmRepost,
    isPending,
    selectedUser
  };
}